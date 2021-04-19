using GeoCab.DAL.DataContext;
using GeoCab.DAL.Entities;

namespace GeoCab.DAL.Repositories
{
	public class EmployeeRepository : BaseRepository<Employee>
	{
		public EmployeeRepository(GeoCabDbContext geoCabDbContext) : base(geoCabDbContext)
		{
		}
	}
}