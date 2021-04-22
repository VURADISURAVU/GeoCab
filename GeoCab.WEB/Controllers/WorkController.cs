using GeoCab.BLL.DTO;
using GeoCab.BLL.Interfaces;
using GeoCab.WEB.Middlewares;
using GeoCab.WEB.ViewModels;
using Microsoft.AspNetCore.Mvc;

public class WorkController : Controller
{
	private readonly IWorkService _service;
	private readonly UserMiddleware _middleware;

	public WorkController(IWorkService service, UserMiddleware middleware)
	{
		_service = service;
		_middleware = middleware;
	}

	[HttpGet]
	public IActionResult Index()
	{
		var works = _service.ShowAllWork();
		
		return View(works);
	}

	[HttpGet]
	public IActionResult Create() => View();

	[HttpPost]
	public IActionResult Create(CreateWorkViewModel viewModel)
	{
		var work = new WorkDTO
		{
			Title = viewModel.Title,
			Description = viewModel.Description,
			Cost = viewModel.Cost,
			UserId = _middleware.GetUser().Id
		};
		
		_service.CreateWork(work);
		return RedirectToAction("Index", "Home");
	}
}
