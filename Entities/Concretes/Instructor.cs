namespace Entities.Concretes
{
    public class Instructor : User
    {
        public string CompanyName { get; set; }

        public Instructor()
        {
            
        }

        public Instructor(int id, string userName, string firstName, string lastName, DateTime dateOfBirth, string nationalIdentity,
            string email, string password, string companyName) : this()
        {
            Id = id;
            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            NationalIdentity = nationalIdentity;
            Email = email;
            Password = password;
            CompanyName = companyName;
        }

        public Instructor(string userName, string firstName, string lastName, DateTime dateOfBirth, string nationalIdentity,
            string email, string password, string companyName) : this()
        {
            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            NationalIdentity = nationalIdentity;
            Email = email;
            Password = password;
            CompanyName = companyName;
        }
    }
}