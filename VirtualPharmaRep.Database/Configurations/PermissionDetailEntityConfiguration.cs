using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VirtualPharmaRep.Data.Entities;

namespace VirtualPharmaRep.Database.Configurations
{
    public class PermissionDetailEntityConfiguration : IEntityTypeConfiguration<PermissionDetail>
    {
        public void Configure(EntityTypeBuilder<PermissionDetail> builder)
        {
            builder.ToTable("PermissionDetails");
            builder.HasIndex(pd => pd.RoleName).IsUnique();
        }
    }
}
