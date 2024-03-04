namespace Entities.Concretes
{
    public class Employee : User
    {
        public string Position { get; set; }

        public Employee()
        {
            
        }

        public Employee(int id, string userName, string firstName, string lastName, DateTime dateOfBirth, string nationalIdentity,
            string email, string password, string position) : this()
        {
            Id = id;
            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            NationalIdentity = nationalIdentity;
            Email = email;
            Password = password;
            Position = position;
        }

        public Employee(string userName, string firstName, string lastName, DateTime dateOfBirth, string nationalIdentity,
            string email, string password, string position) : this()
        {
            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            NationalIdentity = nationalIdentity;
            Email = email;
            Password = password;
            Position = position;
        }
    }
}