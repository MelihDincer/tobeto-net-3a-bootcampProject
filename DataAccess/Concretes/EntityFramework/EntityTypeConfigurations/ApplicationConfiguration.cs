using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concretes.EntityFramework.EntityTypeConfigurations
{
    public class ApplicationConfiguration
    {
        public void Configure(EntityTypeBuilder<Application> builder)
        {
            builder.ToTable("Applications").HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id").IsRequired();
            builder.Property(x => x.BootcampId).HasColumnName("BootcampId").IsRequired();
            builder.Property(x => x.ApplicantId).HasColumnName("ApplicantId").IsRequired();
            builder.Property(x => x.ApplicationStateId).HasColumnName("ApplicationStateId").IsRequired();

            builder.HasOne(x => x.Applicant);
            builder.HasOne(x => x.Bootcamp);
            builder.HasOne(x => x.ApplicationState);
        }
    }
}
