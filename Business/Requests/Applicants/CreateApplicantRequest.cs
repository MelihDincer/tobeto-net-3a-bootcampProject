using Business.Responses.Users;

namespace Business.Requests.Applicants
{
    public class CreateApplicantRequest : GetByIdUserResponse
    {
        public int UserId { get; set; }
        public string About { get; set; }
    }
}
