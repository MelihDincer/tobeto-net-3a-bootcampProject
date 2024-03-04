using Core.Entities;

namespace Entities.Concretes
{
    public class BootcampState : BaseEntity<int>
    {
        public string Name { get; set; }

        public BootcampState()
        {
            
        }

        public BootcampState(int id, string name) : this()
        {
            Id = id;
            Name = name;
        }

        public BootcampState(string name) : this()
        {
            Name = name;
        }
    }
}
