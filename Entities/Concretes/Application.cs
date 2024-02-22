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
    }
}
