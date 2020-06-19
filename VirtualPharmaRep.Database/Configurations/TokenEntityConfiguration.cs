using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VirtualPharmaRep.Data.Entities;

namespace VirtualPharmaRep.Database.Configurations
{
    public class TokenEntityConfiguration : IEntityTypeConfiguration<Token>
    {
	    public void Configure(EntityTypeBuilder<Token> builder)
	    {
			builder.ToTable("Tokens");
			builder.Property(i => i.Id).ValueGeneratedOnAdd();
			builder.HasOne(t => t.User).WithMany(u => u.Tokens);
		}
    }
}
