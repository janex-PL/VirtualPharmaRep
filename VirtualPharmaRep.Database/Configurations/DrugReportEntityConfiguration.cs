using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VirtualPharmaRep.Data.Entities;

namespace VirtualPharmaRep.Database.Configurations
{
    public class DrugReportEntityConfiguration : IEntityTypeConfiguration<DrugReport>
    {
        public void Configure(EntityTypeBuilder<DrugReport> builder)
        {
            builder.ToTable("DrugReports");
            builder.HasOne(dr => dr.Visit).WithMany(v => v.DrugReports);
            builder.HasOne(dr => dr.Drug).WithMany(d => d.DrugReports);
            builder.Property(dr => dr.Id).ValueGeneratedOnAdd();
            builder.Property(dr => dr.KnowledgeGrade).HasConversion<string>();
            builder.HasQueryFilter(dr => !dr.IsDeleted);
        }
    }
}
