using Core.Entities;

namespace Entities.Concretes
{
    public class BootcampImage : BaseEntity<int>
    {
        public int BootcampId { get; set; }
        public string ImagePath { get; set; }


        public virtual Bootcamp Bootcamp { get; set; }

        public BootcampImage()
        {

        }

        public BootcampImage(int id, int bootcampId, string imagePath) : this()
        {
            Id = id;
            BootcampId = bootcampId;
            ImagePath = imagePath;
        }

        public BootcampImage(int bootcampId, string imagePath) : this()
        {
            BootcampId = bootcampId;
            ImagePath = imagePath;
        }
    }
}