using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concretes.EntityFramework.EntityTypeConfigurations
{
    public class BootcampImageConfiguration : IEntityTypeConfiguration<BootcampImage>
    {
        public void Configure(EntityTypeBuilder<BootcampImage> builder)
        {
            builder.ToTable("BootcampImages").HasKey("Id");
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.BootcampId).HasColumnName("BootcampId").IsRequired();
            builder.Property(x => x.ImagePath).HasColumnName("ImagePath").IsRequired();

            builder.HasOne(x => x.Bootcamp);
        }
    }
}
