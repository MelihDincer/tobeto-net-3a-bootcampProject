namespace Business.Responses.Applicants
{
    public class CreateApplicantResponse
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string NationalIdentity { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string About { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
