namespace Entities.Concretes
{
    //Başvuran
    public class Applicant : User
    {
        public string About { get; set; }
        public Applicant()
        {
        }

        public Applicant(int id, string about, string userName, string firstName, string lastName,
            DateTime dateOfBirth, string nationalIdentity, string eMail, string password)
        {
            Id = id;
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