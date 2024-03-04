namespace Business.Responses.BootcampStates
{
    public class UpdateBootcampStateResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}