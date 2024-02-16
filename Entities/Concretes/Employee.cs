namespace Entities.Concretes
{
    public class Employee : User
    {
        public string Position { get; set; }

        public Employee()
        {           
        }
        public Employee(int id, string position, string userName, string firstName, string lastName,
            DateTime dateOfBirth, string nationalIdentity, string eMail, string password)
        {
            Id = id;
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