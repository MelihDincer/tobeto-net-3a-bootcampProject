namespace Entities.Concretes
{
    //Başvuran
    public class Applicant : User
    {
        public string About { get; set; }
        public Applicant()
        {
        }

        public Applicant(int userId, string about)
        {
            Id = userId;
            About = about;
        }
    }
}