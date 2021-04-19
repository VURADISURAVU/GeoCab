using System.Collections.Generic;
using GeoCab.BLL.DTO;
using GeoCab.DAL.Entities;

namespace GeoCab.BLL.Interfaces
{
	public interface IUserService
	{
		public void CreateUser(UserDTO userDto);
		public User Login(string name, string password);
		public User GetByName(string username);

		public List<User> ShowAllUsers();
	}
}