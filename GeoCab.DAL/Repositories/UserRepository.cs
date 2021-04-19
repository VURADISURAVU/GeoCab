using System.Linq;
using GeoCab.DAL.DataContext;
using GeoCab.DAL.Entities;
using GeoCab.DAL.Infrastructure;

namespace GeoCab.DAL.Repositories
{
	public class UserRepository : BaseRepository<User>
	{
		public UserRepository(GeoCabDbContext geoCabDbContext) : base(geoCabDbContext)
		{
		}

		public User GetByUsername(string username)
		{
			return _dbContext.Users.SingleOrDefault(x => x.Username == username);
		}

		public User Login(string name, string password)
		{
			var user = _dbContext
				.Users
				.SingleOrDefault(x => x.Username == name);

			if (user != null && !CheckHashedPassword.VerifyHashedPassword(user.Password, password))
			{
				return null;
			}

			return user;
		}
	}
}