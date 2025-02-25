using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExamWeb.Interfaces;
using ExamWeb.JobPostingService;
using ExamWeb.Models;
using ExamWeb.Services;

namespace ExamWeb.Controllers
{
    public class JobPostingController : Controller
    {
        private IJobPostingRepository _jpRepository;
        private IAlumniRepository _alumniRepository;
        public int photoSizeLimit = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["PhotoSizeLimit"]); // 3MB
        public string jobAttachmentsPath = System.Configuration.ConfigurationManager.AppSettings["JobAttachmentsPath"]; // "~/images/AlumniPhotos/"

        public JobPostingController()
        {
            _jpRepository = new JobPostingRepository();
            _alumniRepository = new AlumniRepository();
        }

        // GET: JobPosting
        public ActionResult Index()
        {
            var skills = _jpRepository.GetSkills()
                .Select(s => new { Value = s.SkillID, Text = s.Name })
                .ToList();
            var employmentTypes = _jpRepository.GetEmploymentTypes()
                .Select(a => new SelectListItem
                {
                    Value = a.EmploymentTypeID.ToString(),
                    Text = a.Name
                })
                .ToList();
            ViewBag.AttachmentsList = _jpRepository.GetAttachmentTypes()
                .Select(a => new SelectListItem
                {
                    Value = a.AttachmentTypeID.ToString(),
                    Text = a.Name
                })
                .ToList();
            ViewBag.SkillsList = new MultiSelectList(skills, "Value", "Text");
            ViewBag.EmploymentTypeList = employmentTypes;
            return View();
        }

        public JsonResult GetJobPostings()
        {
            var data = _jpRepository.GetJobPostings();
            var json = Json(new { data = data }, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = int.MaxValue;
            return json;
        }

        public JsonResult GetJobPostingID(Guid jobPostingID)
        {
            var data = _jpRepository.GetJobPostingByID(jobPostingID);
            var result = Mapping.Mapper.Map<JobPostingModel>(data);
            var skills = _jpRepository.GetSkills()
                .Select(s => new { Value = s.SkillID, Text = s.Name })
                .ToList();
            var employmentTypes = _jpRepository.GetEmploymentTypes()
                .Select(a => new SelectListItem
                {
                    Value = a.EmploymentTypeID.ToString(),
                    Text = a.Name
                })
                .ToList();
            ViewBag.AttachmentsList = _jpRepository.GetAttachmentTypes()
                .Select(a => new SelectListItem
                {
                    Value = a.AttachmentTypeID.ToString(),
                    Text = a.Name
                })
                .ToList();
            ViewBag.SkillsList = new MultiSelectList(skills, "Value", "Text");
            ViewBag.EmploymentTypeList = employmentTypes;
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        public ActionResult CreateApplyJob(Guid jobId)
        {
            var job = _jpRepository.GetJobPostingByID(jobId);
            if (job == null)
            {
                return HttpNotFound(); // Jika job tidak ditemukan, kembalikan 404
            }

            // Siapkan ViewBag
            ViewBag.JobPosted = job;
            ViewBag.JobTitle = job.Title;
            ViewBag.JobDescription = job.JobDescription;
            ViewBag.MinExperience = job.MinimumExperience;
            ViewBag.Skills = job.SkillDisplay;
            ViewBag.JobID = jobId;
            ViewBag.AttachmentTypes = job.AttachmentTypeDisplay?.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

            // Ambil daftar alumni dan buat SelectList
            ViewBag.AlumniList = _alumniRepository.GetAlumnis()
                .Select(a => new SelectListItem
                {
                    Value = a.AlumniID.ToString(),
                    Text = $"{a.FirstName} {(a.MiddleName?.Trim() ?? "")} {a.LastName}".Trim()
                })
                .ToList();

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult CreateApplyJob(FormCollection form, HttpPostedFileBase cv, HttpPostedFileBase idCard, HttpPostedFileBase certificate)
        {
            try
            {
                var alumniId = int.Parse(form["alumni"]);
                var jobId = Guid.Parse(form["jobId"]);

                // Simpan JobCandidate
                var jobCandidate = new JobCandidateDTO
                {
                    AlumniID = alumniId,
                    JobID = jobId,
                    ApplyDate = DateTime.Now
                };

                //_jpRepository.InsertJobApply(jobCandidate);

                // Simpan file sebagai JobAttachment
                List<JobAttachmentDTO> attachments = new List<JobAttachmentDTO>();

                if (cv != null && cv.ContentLength > 0)
                {
                    attachments.Add(SaveAttachment(cv, alumniId, jobId, 1)); // 1 = CV
                }
                if (idCard != null && idCard.ContentLength > 0)
                {
                    attachments.Add(SaveAttachment(idCard, alumniId, jobId, 2)); // 2 = ID Card
                }
                if (certificate != null && certificate.ContentLength > 0)
                {
                    attachments.Add(SaveAttachment(certificate, alumniId, jobId, 3)); // 3 = Certificate
                }

                // Pastikan setidaknya satu dokumen ada
                if (!attachments.Any())
                {
                    return Json(new { success = false, message = "All documents (CV, ID Card, Certificate) are required!" });
                }

                _jpRepository.InsertJobAttachments(attachments);

                return Json(new { success = true, message = "Application submitted successfully!" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        private JobAttachmentDTO SaveAttachment(HttpPostedFileBase file, int alumniId, Guid jobId, byte attachmentType)
        {
            string uploadsFolder = Server.MapPath("~/Uploads");
            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);
            file.SaveAs(filePath);

            return new JobAttachmentDTO
            {
                AlumniID = alumniId,
                JobID = jobId,
                AttachmentTypeID = attachmentType,
                FilePath = "/Uploads/" + uniqueFileName,
                FileName = file.FileName,
                ApplyDate = DateTime.Now
            };
        }


        // GET: JobPosting/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: JobPosting/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(JobPostingModel jobPosting)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if(jobPosting.SelectedAttachmentTypes == null || jobPosting.SelectedSkills == null)
                    {
                        return Json(new { success = false, message = "Attachment types and skills are required." });
                    }
                    //_jpRepository.InsertJobPosting(jobPosting);
                    //jobPosting.JobID = Guid.NewGuid();
                    //jobPosting.ModifiedDate = DateTime.Now;
                    _jpRepository.UpsertJobPosting(jobPosting);
                    return Json(new { success = true , message = "Job posting created successfully." });
                }
                //dihapus diganti dengan yang lain, return viewnya, bukan swal
                //return Json(new { error = true, errorMsg = "Error adding job posting" });
                return View(jobPosting);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, errorMsg = "Error deleting job posting: " + ex.Message });
            }
        }

        // POST: JobPosting/Edit/5
        [HttpPost]
        public ActionResult Edit(JobPostingModel jobPosting)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var existingData = _jpRepository.GetJobPostingByID(jobPosting.JobID);
                    if (existingData == null)
                    {
                        return HttpNotFound();
                    }
                    existingData.ModifiedDate = DateTime.Now;
                    _jpRepository.UpsertJobPosting(jobPosting);
                    TempData["SuccessMessage"] = "Alumni updated successfully!";
                    return Json(new { success = true });
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Unable to save job posting: " + ex.Message);
                return Json(new { error = true, errorMsg = ex.Message });
            }
            return View(jobPosting);
        }

        // GET: JobPosting/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: JobPosting/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id, FormCollection collection)
        {
            try
            {
                var existingData = _jpRepository.GetJobPostingByID(id);
                if (existingData == null)
                {
                    return HttpNotFound();
                }
                _jpRepository.DeleteJobPosting(id);
                return Json(new { success = true, message = "Job posting deleted successfully" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error deleting job posting: " + ex.Message });
            }
        }
    }
}
