using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamWeb.JobPostingService;
using ExamWeb.Models;

namespace ExamWeb.Interfaces
{
    public interface IJobPostingRepository
    {
        IEnumerable<JobPostingDTO> GetJobPostings();
        JobPostingDTO GetJobPostingByID(Guid id);
        void InsertJobPosting(JobPostingModel jobPostingDTO);
        void UpdateJobPosting(JobPostingModel jobPostingDTO);
        void DeleteJobPosting(Guid id);
    }
}
