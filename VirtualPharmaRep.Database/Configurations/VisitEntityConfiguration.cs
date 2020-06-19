using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VirtualPharmaRep.Data.Entities;

namespace VirtualPharmaRep.Database.Configurations
{
    public class VisitEntityConfiguration : IEntityTypeConfiguration<Visit>
    {
        public void Configure(EntityTypeBuilder<Visit> builder)
        {
            builder.ToTable("Visits");
            builder.HasOne(v => v.DoctorEmployment).WithMany(de => de.Visits);
            builder.HasOne(v => v.User).WithMany(u => u.Visits);
            builder.HasMany(v => v.DrugReports).WithOne(dr => dr.Visit);
            builder.Property(v => v.Id).ValueGeneratedOnAdd();
            builder.HasQueryFilter(v => !v.IsDeleted);
        }
    }
}
