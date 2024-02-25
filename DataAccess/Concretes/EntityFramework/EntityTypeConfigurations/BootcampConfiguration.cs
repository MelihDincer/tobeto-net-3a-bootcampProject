using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concretes.EntityFramework.EntityTypeConfigurations
{
    public class BootcampConfiguration
    {
        public void Configure(EntityTypeBuilder<Bootcamp> builder)
        {
            builder.ToTable("Bootcamps").HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id").IsRequired();
            builder.Property(x => x.Name).HasColumnName("Name").IsRequired();
            builder.Property(x => x.InstructorId).HasColumnName("InstructorId").IsRequired();
            builder.Property(x => x.BootcampStateId).HasColumnName("BootcampStateId").IsRequired();
            builder.Property(x => x.StartDate).HasColumnName("StartDate").IsRequired();
            builder.Property(x => x.EndDate).HasColumnName("EndDate").IsRequired();

            builder.HasOne(x => x.Instructor);
            builder.HasOne(x => x.BootcampState);
            builder.HasMany(x => x.Applications);
            builder.HasMany(x => x.BootcampImages);
        }
    }
}
