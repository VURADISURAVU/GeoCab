using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace GeoCab.DAL.DataContext
{
	public class DatabaseContextFactory : IDesignTimeDbContextFactory<GeoCabDbContext>
	{
		public GeoCabDbContext CreateDbContext(string[] args)
		{
			AppConfiguration appConfig = new AppConfiguration();
			var opsBuilder = new DbContextOptionsBuilder<GeoCabDbContext>();
			opsBuilder.UseSqlServer(appConfig.SqlConnectionString);
			return new GeoCabDbContext(opsBuilder.Options);
		}
	}
}