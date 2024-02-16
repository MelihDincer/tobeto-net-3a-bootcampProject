using Core.Entities;
namespace Entities.Concretes
{
    public class Instructor : User
    {
        public string CompanyName { get; set; }
        public Instructor()
        {
        }

        public Instructor(int id, string companyName, string userName, string firstName, string lastName,
            DateTime dateOfBirth, string nationalIdentity, string eMail, string password)
        {
            Id = id;
            CompanyName = companyName;
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