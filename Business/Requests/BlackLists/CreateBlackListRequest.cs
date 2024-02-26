namespace Business.Requests.BlackLists
{
    public class CreateBlackListRequest
    {
        public string Reason { get; set; }
        public DateTime Date { get; set; }
        public int ApplicantId { get; set; }
    }
}