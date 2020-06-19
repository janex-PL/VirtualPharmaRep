using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VirtualPharmaRep.Data.Entities;

namespace VirtualPharmaRep.Database.Configurations
{
    public class ClinicEntityConfiguration : IEntityTypeConfiguration<Clinic>
    {
        public void Configure(EntityTypeBuilder<Clinic> builder)
        {
            builder.ToTable("Clinics");
            builder.HasMany(c => c.DoctorEmployments).WithOne(de => de.Clinic);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.HasQueryFilter(c => !c.IsDeleted);
        }

    }
}
