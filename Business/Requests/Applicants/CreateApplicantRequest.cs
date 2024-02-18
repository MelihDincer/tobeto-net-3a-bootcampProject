using System.ComponentModel.DataAnnotations.Schema;

namespace Business.Requests.Applicants
{
    public class CreateApplicantRequest
    {
        public int UserId { get; set; }
        public string About { get; set; }
    }
}
