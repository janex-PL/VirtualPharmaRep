using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VirtualPharmaRep.Data.Entities;

namespace VirtualPharmaRep.Database.Configurations
{
    public class DoctorEmploymentEntityConfiguration : IEntityTypeConfiguration<DoctorEmployment>
    {
	    public void Configure(EntityTypeBuilder<DoctorEmployment> builder)
	    {
			builder.ToTable("DoctorEmployments");
			builder.HasOne(de => de.Doctor).WithMany(d => d.DoctorEmployments);
			builder.HasOne(de => de.Clinic).WithMany(c => c.DoctorEmployments);
			builder.Property(de => de.Id).ValueGeneratedOnAdd();
            builder.HasQueryFilter(de => !de.IsDeleted);
        }
    }
}
