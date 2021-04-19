using GeoCab.WEB.Middlewares;
using GeoCab.WEB.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GeoCab.WEB.Controllers
{
	public class HomeController : Controller
	{
		private readonly UserMiddleware _middleware;
		
		public HomeController(UserMiddleware middleware)
		{
			_middleware = middleware;
		}
		
		[HttpGet]
		public IActionResult Index()
		{
			var userName = new IndexViewModel();
			if (_middleware.GetUser() == null)
			{
				userName.Name = "Посетитель";
			}
			else
			{
				userName.Name = _middleware.GetUser().Username;
			}
			
			return View(userName);
		}
	}
}