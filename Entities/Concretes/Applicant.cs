namespace Entities.Concretes
{
    //Başvuran
    public class Applicant : User
    {
        public int UserId { get; set; }
        public string About { get; set; }
        public Applicant()
        {
        }

        public Applicant(int id, int userId, string about, string userName, string firstName, string lastName,
            DateTime dateOfBirth, string nationalIdentity, string eMail, string password)
        {
            Id = id;
            UserId = userId;
            About = about;
            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            NationalIdentity = nationalIdentity;
            Email = eMail;
            Password = password;
        }
    }
}