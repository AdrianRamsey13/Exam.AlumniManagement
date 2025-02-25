using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExamWeb.Interfaces;
using ExamWeb.Models;
using ExamWeb.Services;

namespace ExamWeb.Controllers
{
    public class CandidateController : Controller
    {
        private ICandidateRepository _candidateRepository;

        public CandidateController()
        {
            _candidateRepository = new CandidateRepository();
        }

        // GET: Candidate
        public ActionResult Index(Guid jobId)
        {
            ViewBag.JobID = jobId;
            var candidates = _candidateRepository.GetCandidates(jobId);
            var candidatesJson = Newtonsoft.Json.JsonConvert.SerializeObject(candidates);
            ViewBag.CandidatesJson = candidatesJson;
            return View();
        }

        public JsonResult GetCandidates(Guid jobId)
        {
            var candidates = _candidateRepository.GetCandidates(jobId);
            var json = Json(new { data = candidates }, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = int.MaxValue;
            return json;
        }

        // GET: Candidate/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Candidate/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Candidate/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Candidate/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Candidate/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Candidate/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Candidate/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
