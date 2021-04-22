using GeoCab.DAL.DataContext;
using GeoCab.DAL.Entities;

namespace GeoCab.DAL.Repositories
{
	public class WorkRepository : BaseRepository<Work>
	{
		public WorkRepository(GeoCabDbContext geoCabDbContext) : base(geoCabDbContext)
		{
		}
	}
}