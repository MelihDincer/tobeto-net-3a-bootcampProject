namespace Business.Responses.BlackLists
{
    public class GetByApplicantIdBlackListResponse
    {
        public int Id { get; set; }
        public string ApplicantUserName { get; set; }
        public string ApplicantFirstName { get; set; }
        public string ApplicantLastName { get; set; }
        public DateTime Date { get; set; }
        public string Reason { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
