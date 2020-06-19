using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VirtualPharmaRep.Data.Entities;

namespace VirtualPharmaRep.Database.Configurations
{
    public class TeamMemberEntityConfiguration : IEntityTypeConfiguration<TeamMember>
    {
	    public void Configure(EntityTypeBuilder<TeamMember> builder)
	    {
			builder.ToTable("TeamMembers");
			builder.HasOne(tm => tm.User).WithMany(u => u.TeamMembers);
			builder.HasOne(tm => tm.Team).WithMany(t => t.TeamMembers);
			builder.Property(tm => tm.Id).ValueGeneratedOnAdd();
            builder.HasQueryFilter(tm => !tm.IsDeleted);
		}
    }
}
