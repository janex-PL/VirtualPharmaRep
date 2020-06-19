using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VirtualPharmaRep.Data.Entities;

namespace VirtualPharmaRep.Database.Configurations
{
    public class DrugPropertyReportEntityConfiguration : IEntityTypeConfiguration<DrugPropertyReport>
    {
        public void Configure(EntityTypeBuilder<DrugPropertyReport> builder)
        {
            builder.ToTable("DrugPropertyReports");
            builder.HasOne(dpr => dpr.DrugProperty).WithMany(dp => dp.DrugPropertyReports)
                .OnDelete(DeleteBehavior.NoAction);
            builder.Property(dpr => dpr.Id).ValueGeneratedOnAdd();
            builder.Property(dpr => dpr.Grade).HasConversion<string>();
            builder.HasQueryFilter(dpr => !dpr.IsDeleted);
        }
    }
}
