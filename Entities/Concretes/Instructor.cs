using Core.Entities;
namespace Entities.Concretes
{
    public class Instructor : User
    {
        public int UserId { get; set; }
        public string CompanyName { get; set; }
        public Instructor()
        {
        }

        public Instructor(int id, int userId, string companyName, string userName, string firstName, string lastName,
            DateTime dateOfBirth, string nationalIdentity, string eMail, string password)
        {
            Id = id;
            UserId = userId;
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