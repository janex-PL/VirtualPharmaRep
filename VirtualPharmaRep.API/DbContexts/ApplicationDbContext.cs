using Microsoft.EntityFrameworkCore;
using VirtualPharmaRep.API.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace VirtualPharmaRep.API.DbContexts
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		public ApplicationDbContext(DbContextOptions options) : base(options)
		{ }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Clinic>().ToTable("Clinics");
			modelBuilder.Entity<Clinic>().HasMany(c => c.DoctorEmployments).WithOne(de => de.Clinic);
			modelBuilder.Entity<Clinic>().Property(c => c.Id).ValueGeneratedOnAdd();

			modelBuilder.Entity<Doctor>().ToTable("Doctors");
			modelBuilder.Entity<Doctor>().HasMany(d => d.DoctorEmployments).WithOne(de => de.Doctor);
			modelBuilder.Entity<Doctor>().Property(d => d.Id).ValueGeneratedOnAdd();

			modelBuilder.Entity<DoctorEmployment>().ToTable("DoctorEmployments");
			modelBuilder.Entity<DoctorEmployment>().HasOne(de => de.Doctor).WithMany(d => d.DoctorEmployments);
			modelBuilder.Entity<DoctorEmployment>().HasOne(de => de.Clinic).WithMany(c => c.DoctorEmployments);
			modelBuilder.Entity<DoctorEmployment>().Property(de => de.Id).ValueGeneratedOnAdd();

			modelBuilder.Entity<Drug>().ToTable("Drugs");
			modelBuilder.Entity<Drug>().HasOne(d => d.DrugCategory).WithMany(dc => dc.Drugs);
			modelBuilder.Entity<Drug>().HasMany(d => d.DrugProperties).WithOne(dp => dp.Drug);
			modelBuilder.Entity<Drug>().Property(d => d.Id).ValueGeneratedOnAdd();

			modelBuilder.Entity<DrugCategory>().ToTable("DrugCategories");
			modelBuilder.Entity<DrugCategory>().HasMany(dc => dc.Drugs).WithOne(d => d.DrugCategory);
			modelBuilder.Entity<DrugCategory>().Property(dc => dc.Id).ValueGeneratedOnAdd();

			modelBuilder.Entity<DrugProperty>().ToTable("DrugProperties");
			modelBuilder.Entity<DrugProperty>().HasOne(dp => dp.Drug).WithMany(d => d.DrugProperties);
			modelBuilder.Entity<DrugProperty>().HasMany(dp => dp.DrugPropertyReports).WithOne(dpr => dpr.DrugProperty);
			modelBuilder.Entity<DrugProperty>().Property(dp => dp.Id).ValueGeneratedOnAdd();

			modelBuilder.Entity<DrugPropertyReport>().ToTable("DrugPropertyReports");
			modelBuilder.Entity<DrugPropertyReport>().HasOne(dpr => dpr.Grade).WithMany(g => g.DrugPropertyReports);
			modelBuilder.Entity<DrugPropertyReport>().HasOne(dpr => dpr.DrugProperty).WithMany(dp => dp.DrugPropertyReports);
			modelBuilder.Entity<DrugPropertyReport>().HasOne(dpr => dpr.Visit).WithMany(v => v.DrugPropertyReports);
			modelBuilder.Entity<DrugPropertyReport>().Property(dpr => dpr.Id).ValueGeneratedOnAdd();

			modelBuilder.Entity<Grade>().ToTable("Grades");
			modelBuilder.Entity<Grade>().HasMany(g => g.DrugPropertyReports).WithOne(dpr => dpr.Grade);
			modelBuilder.Entity<Grade>().Property(g => g.Id).ValueGeneratedOnAdd();

			modelBuilder.Entity<Team>().ToTable("Teams");
			modelBuilder.Entity<Team>().HasMany(t => t.TeamMembers).WithOne(tm => tm.Team);
			modelBuilder.Entity<Team>().Property(t => t.Id).ValueGeneratedOnAdd();

			modelBuilder.Entity<TeamMember>().ToTable("TeamMembers");
			modelBuilder.Entity<TeamMember>().HasOne(tm => tm.User).WithMany(u => u.TeamMembers);
			modelBuilder.Entity<TeamMember>().HasOne(tm => tm.Team).WithMany(t => t.TeamMembers);
			modelBuilder.Entity<TeamMember>().Property(tm => tm.Id).ValueGeneratedOnAdd();

			modelBuilder.Entity<ApplicationUser>().ToTable("Users");
			modelBuilder.Entity<ApplicationUser>().HasMany(u => u.TeamMembers).WithOne(tm => tm.User);
			modelBuilder.Entity<ApplicationUser>().Property(u => u.Id).ValueGeneratedOnAdd();

			modelBuilder.Entity<Visit>().ToTable("Visits");
			modelBuilder.Entity<Visit>().HasOne(v => v.DoctorEmployment).WithMany(de => de.Visits);
			modelBuilder.Entity<Visit>().HasOne(v => v.User).WithMany(u => u.Visits);
			modelBuilder.Entity<Visit>().HasMany(v => v.DrugPropertyReports).WithOne(dpr => dpr.Visit);
			modelBuilder.Entity<Visit>().Property(v => v.Id).ValueGeneratedOnAdd();

		}
		public DbSet<Clinic> Clinics { get; set; }
		public DbSet<Doctor> Doctors { get; set; }
		public DbSet<DoctorEmployment> DoctorEmployments { get; set; }
		public DbSet<Drug> Drugs { get; set; }
		public DbSet<DrugCategory> DrugCategories { get; set; }
		public DbSet<DrugPropertyReport> DrugPropertyReports { get; set; }
		public DbSet<Grade> Grades { get; set; }
		public DbSet<Team> Teams { get; set; }
		public DbSet<TeamMember> TeamMembers { get; set; }
		public DbSet<Visit> Visits { get; set; }
	}
}