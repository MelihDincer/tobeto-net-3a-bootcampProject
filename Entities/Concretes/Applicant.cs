namespace Entities.Concretes
{
    //Başvuran
    public class Applicant : User
    {
        public string About { get; set; }
        public BlackList BlackList { get; set; }
        public ICollection<Application> Applications { get; set; }

        public Applicant()
        {
            Applications = new HashSet<Application>();
        }

        public Applicant(int id, string userName, string firstName, string lastName, DateTime dateOfBirth, string nationalIdentity, 
            string email, string password, string about) : this()
        {
            Id = id;
            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            NationalIdentity = nationalIdentity;
            Email = email;
            Password = password;
            About = about;
        }

        public Applicant(string userName, string firstName, string lastName, DateTime dateOfBirth, string nationalIdentity,
            string email, string password, string about) : this()
        {
            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            NationalIdentity = nationalIdentity;
            Email = email;
            Password = password;
            About = about;
        }
    }
}