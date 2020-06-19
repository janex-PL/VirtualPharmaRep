using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VirtualPharmaRep.Data.Entities;

namespace VirtualPharmaRep.Database.Configurations
{
    public class DrugEntityConfiguration : IEntityTypeConfiguration<Drug>
    {
        public void Configure(EntityTypeBuilder<Drug> builder)
        {
            builder.ToTable("Drugs");
            builder.HasOne(d => d.DrugCategory).WithMany(dc => dc.Drugs);
            builder.HasMany(d => d.DrugProperties).WithOne(dp => dp.Drug);
            builder.HasMany(d => d.DrugReports).WithOne(dr => dr.Drug);
            builder.Property(d => d.Id).ValueGeneratedOnAdd();
            builder.HasQueryFilter(d => !d.IsDeleted);
        }
    }
}
