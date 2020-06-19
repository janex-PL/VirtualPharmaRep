using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VirtualPharmaRep.Data.Entities;

namespace VirtualPharmaRep.Database.Configurations
{
    public class DrugCategoryEntityConfiguration : IEntityTypeConfiguration<DrugCategory>
    {
        public void Configure(EntityTypeBuilder<DrugCategory> builder)
        {
            builder.ToTable("DrugCategories");
            builder.HasMany(dc => dc.Drugs).WithOne(d => d.DrugCategory);
            builder.Property(dc => dc.Id).ValueGeneratedOnAdd();
            builder.HasIndex(dc => dc.Name).IsUnique();
            builder.HasQueryFilter(dc => !dc.IsDeleted);
        }
    }
}
