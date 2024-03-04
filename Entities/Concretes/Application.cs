using Core.Entities;

namespace Entities.Concretes
{
    public class Application : BaseEntity<int>
    {
        public int ApplicantId { get; set; }
        public int BootcampId { get; set; }
        public int ApplicationStateId { get; set; }
        public Applicant Applicant { get; set; }
        public Bootcamp Bootcamp { get; set; }
        public ApplicationState ApplicationState { get; set; }

        public Application()
        {
            
        }

        public Application(int id, int applicantId, int bootcampId, int applicationStatedId) : this()
        {
            Id = id;
            ApplicantId = applicantId;
            BootcampId = bootcampId;
            ApplicationStateId = applicationStatedId;
        }

        public Application(int applicantId, int bootcampId, int applicationStatedId) : this()
        {
            ApplicantId = applicantId;
            BootcampId = bootcampId;
            ApplicationStateId = applicationStatedId;
        }
    }
}
