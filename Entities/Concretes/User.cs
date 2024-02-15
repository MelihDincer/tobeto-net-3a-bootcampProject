using Core.Entities;

namespace Entities.Concretes
{
    public class User : BaseEntity<int>
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string NationalIdentity { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Applicant> Applicants { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Instructor> Instructors { get; set; }

        public User()
        {
            Applicants = new HashSet<Applicant>();
            Employees = new HashSet<Employee>();
            Instructors = new HashSet<Instructor>();
        }
        public User(string userName, string firstName, string lastName, DateTime dateOfBirth, string nationalIdentity, string email, string password, ICollection<Applicant> applicants, ICollection<Employee> employees, ICollection<Instructor> ınstructors)
        {
            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            NationalIdentity = nationalIdentity;
            Email = email;
            Password = password;
            Applicants = applicants;
            Employees = employees;
            Instructors = ınstructors;
        }
    }
}