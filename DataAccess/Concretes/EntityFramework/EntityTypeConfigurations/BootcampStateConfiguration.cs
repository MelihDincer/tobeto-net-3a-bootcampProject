using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concretes.EntityFramework.EntityTypeConfigurations
{
    public class BootcampStateConfiguration
    {
        public void Configure(EntityTypeBuilder<BootcampState> builder)
        {
            builder.ToTable("BootcampStates").HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id").IsRequired();
            builder.Property(x => x.Name).HasColumnName("Name").IsRequired();
        }
    }
}
