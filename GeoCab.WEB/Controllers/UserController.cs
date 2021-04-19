using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using GeoCab.BLL.DTO;
using GeoCab.BLL.Interfaces;
using GeoCab.DAL.Entities;
using GeoCab.WEB.Controllers.CustomFilterAttributes;
using GeoCab.WEB.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace GeoCab.WEB.Controllers
{
	public class UserController : Controller
	{
		private readonly IUserService _userService;
		
		public UserController(IUserService userService)
		{
			_userService = userService;
		}

		[HttpGet]
		public IActionResult Login() => View();

		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModel viewModel)
		{
			if (!ModelState.IsValid)
			{
				return View(viewModel);
			}
			
			var user = _userService.Login(viewModel.Username, viewModel.Password);

			if (user == null)
			{
				ModelState.AddModelError("Username", "Такой комбинации не существует");
				return View();
			}

			var pages = new List<Claim>()
			{
				new Claim("Id", user.Id.ToString()),
				new Claim("Name", user.Username),
				new Claim(ClaimTypes.AuthenticationMethod, Startup.AuthMethod)
			};
			
			var claimsIdentity = new ClaimsIdentity(pages, Startup.AuthMethod);
			var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
			await HttpContext.SignInAsync(claimsPrincipal);
			
			return RedirectToAction("Index", "Home");
		}

		[HttpGet]
		public IActionResult Create() => View();
		
		[HttpPost]
		public IActionResult Create(CreateUserViewModel viewModel)
		{
			var newUser = new UserDTO
			{
				Email = viewModel.Email,
				Password = viewModel.Password,
				Username = viewModel.Username
			};

			_userService.CreateUser(newUser);
			return RedirectToAction("Index", "Home");
		}
		
		[HttpGet]
		public IActionResult Index()
		{
			var users = _userService.ShowAllUsers().ToList();

			return View(users);
		}

		public async Task<IActionResult> Exit()
		{
			await HttpContext.SignOutAsync();
			return RedirectToAction("Index", "Home");
		}

		[HttpGet]
		[IsAdmin]
		public IActionResult Users()
		{
			var users = _userService.ShowAllUsers();
			return View(users);
		}
	}
}