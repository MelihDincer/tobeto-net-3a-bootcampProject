using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concretes.EntityFramework.EntityTypeConfigurations
{
    public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.Property(x => x.UserId).HasColumnName("UserId").IsRequired();
            builder.Property(x => x.CompanyName).HasColumnName("CompanyName").IsRequired();

            builder.HasOne(x => x.User);
        }
    }
}
