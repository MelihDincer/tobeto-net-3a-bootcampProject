using Core.Entities;

namespace Entities.Concretes
{
    public class BlackList : BaseEntity<int>
    {
        public int ApplicantId { get; set; }
        public string? Reason { get; set; }
        public DateTime Date { get; set; }
        public Applicant Applicant { get; set; }

        public BlackList()
        {
            
        }

        public BlackList(int id, int applicantId, string reason, DateTime dateTime) : this()
        {
            Id = id;
            ApplicantId = applicantId;
            Reason = reason;
            Date = dateTime;
        }

        public BlackList(int applicantId, string reason, DateTime dateTime) : this()
        {
            ApplicantId = applicantId;
            Reason = reason;
            Date = dateTime;
        }
    }
}