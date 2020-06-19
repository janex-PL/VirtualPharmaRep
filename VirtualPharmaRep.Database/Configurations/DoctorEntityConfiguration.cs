using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VirtualPharmaRep.Data.Entities;

namespace VirtualPharmaRep.Database.Configurations
{
    public class DoctorEntityConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.ToTable("Doctors");
            builder.HasMany(d => d.DoctorEmployments).WithOne(de => de.Doctor);
            builder.Property(d => d.Id).ValueGeneratedOnAdd();
            builder.HasQueryFilter(d => !d.IsDeleted);
        }
    }
}
