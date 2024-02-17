namespace Entities.Concretes
{
    public class Instructor : User
    {
        public string CompanyName { get; set; }

        public Instructor()
        {
        }

        public Instructor(int userId, string companyName)
        {
            Id = userId;
            CompanyName = companyName;
        }
    }
}