using System;

namespace ExamWeb.Controllers
{
    internal class JobCandidateDTO
    {
        public int AlumniID { get; set; }
        public Guid JobID { get; set; }
        public DateTime ApplyDate { get; set; }
    }
}