using Core.Entities;

namespace Entities.Concretes
{
    public class ApplicationState : BaseEntity<int>
    {
        public string Name { get; set; }

        public ApplicationState()
        {
            
        }

        public ApplicationState(int id, string name) : this()
        {
            Id = id;
            Name = name;
        }

        public ApplicationState(string name) : this()
        {
            Name = name;
        }
    }
}
