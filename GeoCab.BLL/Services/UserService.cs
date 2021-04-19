using System.Collections.Generic;
using GeoCab.BLL.DTO;
using GeoCab.BLL.Interfaces;
using GeoCab.DAL.Entities;
using GeoCab.DAL.Repositories;

namespace GeoCab.BLL.Services
{
	public class UserService : IUserService
	{
		private readonly UserRepository _userRepository;
		
		public UserService(UserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public User GetByName(string name)
		{
			return _userRepository.GetByUsername(name);
		}

		public User Login(string name, string password)
		{
			return _userRepository.Login(name, password);
		}

		public void CreateUser(UserDTO userDto)
		{
			var newUser = new User
			{
				Username = userDto.Username,
				Email = userDto.Email,
				Password = HashPasswordService.HashPassword(userDto.Password)
			};

			_userRepository.Save(newUser);
		}

		public List<User> ShowAllUsers()
		{
			return _userRepository.GetAll();
		}
	}
}