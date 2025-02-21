using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExamWeb.JobPostingService;
using ExamWeb.Models;
using ExamWeb.Interfaces;

namespace ExamWeb.Services
{
    public class JobPostingRepository : IJobPostingRepository
    {
        private readonly JobPostingServiceClient _jpServiceClient;

        public JobPostingRepository()
        {
            _jpServiceClient = new JobPostingServiceClient();
        }

        public JobPostingDTO GetJobPostingByID(Guid id)
        {
            var data = _jpServiceClient.GetJobPostingByID(id);
            return data;
        }

        public IEnumerable<JobPostingDTO> GetJobPostings()
        {
            var data = _jpServiceClient.GetJobPostings();
            return data;
        }

        public void InsertJobPosting(JobPostingModel jobPostingDTO)
        {
            var result = Mapping.Mapper.Map<JobPostingDTO>(jobPostingDTO);
            _jpServiceClient.InsertJobPosting(result);
        }

        public void UpdateJobPosting(JobPostingModel jobPostingDTO)
        {
            var result = Mapping.Mapper.Map<JobPostingDTO>(jobPostingDTO);
            _jpServiceClient.UpdateJobPosting(result);
        }
        public void DeleteJobPosting(Guid id)
        {
            _jpServiceClient.DeleteJobPosting(id);
        }
    }
}