using System.Collections.Generic;
using System.Linq;
using GeoCab.DAL.DataContext;
using GeoCab.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace GeoCab.DAL.Repositories
{
	public class ToolRepository : BaseRepository<Tool>
	{
		public ToolRepository(GeoCabDbContext geoCabDbContext) : base(geoCabDbContext)
		{
			
		}
	}
}