using GeoCab.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace GeoCab.DAL.DataContext
{
	public class GeoCabDbContext : DbContext
	{
		public class OptionsBuild
		{
			public OptionsBuild()
			{
				Settings = new AppConfiguration();
				OpsBuilder = new DbContextOptionsBuilder<GeoCabDbContext>();
				OpsBuilder.UseSqlServer(Settings.SqlConnectionString);
				DbOptions = OpsBuilder.Options;
;			}
			
			public DbContextOptionsBuilder<GeoCabDbContext> OpsBuilder { get; set; }
			public DbContextOptions<GeoCabDbContext> DbOptions { get; set; }
			private AppConfiguration Settings { get; set; }
		}

		public static OptionsBuild ops = new OptionsBuild();
		
		public GeoCabDbContext(DbContextOptions<GeoCabDbContext> options) : base(options) {}
		
		public DbSet<User> Users { get; set; }
		public DbSet<Tool> Tools { get; set; }
		public DbSet<Work> Works { get; set; }
		public DbSet<Admin> Admins { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User>()
				.HasOne(x => x.Admin)
				.WithOne(x => x.User);

			modelBuilder.Entity<Admin>()
				.HasOne(a => a.User)
				.WithOne(a => a.Admin);
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseLazyLoadingProxies();
			base.OnConfiguring(optionsBuilder);
		}
	}
}