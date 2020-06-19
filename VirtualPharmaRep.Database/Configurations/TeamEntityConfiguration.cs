using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VirtualPharmaRep.Data.Entities;

namespace VirtualPharmaRep.Database.Configurations
{
    public class TeamEntityConfiguration : IEntityTypeConfiguration<Team>
    {
	    public void Configure(EntityTypeBuilder<Team> builder)
	    {
			builder.ToTable("Teams");
			builder.HasMany(t => t.TeamMembers).WithOne(tm => tm.Team);
			builder.Property(t => t.Id).ValueGeneratedOnAdd();
            builder.HasQueryFilter(t => !t.IsDeleted);
		}
    }
}
