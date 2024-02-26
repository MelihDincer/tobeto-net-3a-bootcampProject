using Core.Entities;

namespace Entities.Concretes
{
    public class BlackList : BaseEntity<int>
    {
        public string? Reason { get; set; }
        public DateTime Date { get; set; }
        public int ApplicantId { get; set; }
        public Applicant Applicant { get; set; }
    }
}