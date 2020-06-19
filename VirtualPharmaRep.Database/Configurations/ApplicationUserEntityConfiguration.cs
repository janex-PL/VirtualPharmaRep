using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VirtualPharmaRep.Data.Entities;

namespace VirtualPharmaRep.Database.Configurations
{
    public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.ToTable("Users");
            builder.HasMany(u => u.Visits).WithOne(v => v.User);
            builder.HasMany(u => u.TeamMembers).WithOne(tm => tm.User);
            builder.HasMany(u => u.Tokens).WithOne(t => t.User);
            builder.HasQueryFilter(u => !u.IsDeleted);
        }

    }
}
