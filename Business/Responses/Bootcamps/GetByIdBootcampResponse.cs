namespace Business.Responses.Bootcamps
{
    public class GetByIdBootcampResponse
    {
        public string Name { get; set; }
        public string InstructorFirstName { get; set; }
        public string InstructorLastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string NationalIdentity { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string CompanyName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string BootcampStateName { get; set; }
    }
}