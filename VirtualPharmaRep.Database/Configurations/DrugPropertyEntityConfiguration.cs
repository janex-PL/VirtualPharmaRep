using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VirtualPharmaRep.Data.Entities;

namespace VirtualPharmaRep.Database.Configurations
{
    public class DrugPropertyEntityConfiguration : IEntityTypeConfiguration<DrugProperty>
    {
        public void Configure(EntityTypeBuilder<DrugProperty> builder)
        {
            builder.ToTable("DrugProperties");
            builder.HasOne(dp => dp.Drug).WithMany(d => d.DrugProperties);
            builder.HasMany(dp => dp.DrugPropertyReports).WithOne(dpr => dpr.DrugProperty);
            builder.Property(dp => dp.Id).ValueGeneratedOnAdd();
            builder.HasQueryFilter(dp => !dp.IsDeleted);
        }
    }
}
