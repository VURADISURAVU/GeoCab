using System.Linq;
using GeoCab.DAL.Entities;
using GeoCab.DAL.Repositories;
using Microsoft.AspNetCore.Http;

namespace GeoCab.WEB.Middlewares
{
	public class UserMiddleware
	{
		private readonly UserRepository _userRepository;
		private readonly IHttpContextAccessor _accessor;

		public UserMiddleware(UserRepository userRepository, IHttpContextAccessor accessor)
		{
			_userRepository = userRepository;
			_accessor = accessor;
		}

		public User GetUser()
		{
			var idStr = _accessor.HttpContext.User.Claims.SingleOrDefault(x => x.Type == "Id")?.Value;
			
			if (string.IsNullOrEmpty(idStr))
			{
				return null;
			}
			
			var id = int.Parse(idStr);
			return _userRepository.GetById(id);
		}

		public bool IsAdmin() => GetUser()?.Admin != null;
		
		public bool IsEmployee() => GetUser()?.Employee != null;
	}
}