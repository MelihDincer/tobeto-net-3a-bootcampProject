namespace Entities.Concretes
{
    public class Employee : User
    {
        public int UserId { get; set; }
        public string Position { get; set; }

        public Employee()
        {           
        }
        public Employee(int id, int userId, string position, string userName, string firstName, string lastName,
            DateTime dateOfBirth, string nationalIdentity, string eMail, string password)
        {
            Id = id;
            UserId = userId;
            Position = position;
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