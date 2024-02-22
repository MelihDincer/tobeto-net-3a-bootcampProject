namespace Business.Responses.Application
{
    public class GetByIdApplicationResponse
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string NationalIdentity { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string About { get; set; }
        public string BootcampName { get; set; }
        public string ApplicationStateName { get; set; }
    }
}
