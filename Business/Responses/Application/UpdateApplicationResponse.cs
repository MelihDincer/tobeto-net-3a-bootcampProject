namespace Business.Responses.Application
{
    public class UpdateApplicationResponse
    {
        public int Id { get; set; }
        public int ApplicantId { get; set; }
        public int BootcampId { get; set; }
        public int ApplicationStateId { get; set; }
    }
}