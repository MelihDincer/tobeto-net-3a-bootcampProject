using Core.Entities;

namespace Entities.Concretes
{
    public class Bootcamp : BaseEntity<int>
    {
        public string Name { get; set; }
        public int InstructorId { get; set; }
        public int BootcampStateId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Instructor Instructor { get; set; }
        public BootcampState BootcampState { get; set; }
        public ICollection<Application> Applications { get; set; }
        public virtual ICollection<BootcampImage> BootcampImages { get; set; }

        public Bootcamp()
        {
            Applications = new HashSet<Application>();
            BootcampImages = new HashSet<BootcampImage>();
        }

        public Bootcamp(int id, int instructorId, int bootcampStateId, string name, DateTime startDate, DateTime endDate) : this()
        {
            Id = id;
            InstructorId = instructorId;
            BootcampStateId = bootcampStateId;
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
        }

        public Bootcamp(int instructorId, int bootcampStateId, string name, DateTime startDate, DateTime endDate) : this()
        {
            InstructorId = instructorId;
            BootcampStateId = bootcampStateId;
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
