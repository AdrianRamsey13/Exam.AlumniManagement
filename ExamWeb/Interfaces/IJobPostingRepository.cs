using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using ExamWeb.JobAttachmentService;
using ExamWeb.JobPostingService;
using ExamWeb.Models;

namespace ExamWeb.Interfaces
{
    public interface IJobPostingRepository
    {
        IEnumerable<JobPostingDTO> GetJobPostings();
        IEnumerable<SkillsDTO> GetSkills();
        IEnumerable<EmploymentTypeDTO> GetEmploymentTypes();
        IEnumerable<AttachmentTypeDTO> GetAttachmentTypes();
        IEnumerable<JobPostingService.JobAttachmentDTO> GetJobAttachments();
        JobPostingDTO GetJobPostingByID(Guid jobPostingID);
        SkillsDTO GetSkillByID(int skillID);
        EmploymentTypeDTO GetEmploymentTypeByID(byte employmentTypeID);
        AttachmentTypeDTO GetAttachmentTypeByID(byte attachmentTypeID);
        JobPostingService.JobAttachmentDTO GetJobAttachmentByID(int attachmentID);
        void UpsertJobPosting(JobPostingModel jobPosting);
        void InsertJobPosting(JobPostingModel jobPosting);
        void UpdateJobPosting(JobPostingModel jobPosting);
        void DeleteJobPosting(Guid jobPostingID);

        void InsertJobApply(JobCandidateDTO jobCandidate);

        void InsertJobAttachments(List<JobPostingService.JobAttachmentDTO> attachments);

    }
}
