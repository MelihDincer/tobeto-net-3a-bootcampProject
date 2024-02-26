namespace Business.Responses.BlackLists
{
    public class CreateBlackListResponse
    {
        public int Id { get; set; }
        public int ApplicantId { get; set; }
        public DateTime Date { get; set; }
        public string Reason { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
