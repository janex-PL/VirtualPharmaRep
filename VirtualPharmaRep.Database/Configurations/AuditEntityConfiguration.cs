using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VirtualPharmaRep.Database.Audit;

namespace VirtualPharmaRep.Database.Configurations
{
    public class AuditEntityConfiguration : IEntityTypeConfiguration<AuditEntity>
    {
        public void Configure(EntityTypeBuilder<AuditEntity> builder)
        {
            builder.ToTable("Audit");
        }
    }
}
