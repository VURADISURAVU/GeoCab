using System.Collections.Generic;
using GeoCab.BLL.DTO;
using GeoCab.BLL.Interfaces;
using GeoCab.DAL.Entities;
using GeoCab.DAL.Repositories;

namespace GeoCab.BLL.Services
{
	public class WorkService : IWorkService
	{
		private readonly WorkRepository _repository;

		public WorkService(WorkRepository repository)
		{
			_repository = repository;
		}

		public void CreateWork(WorkDTO workDto)
		{
			var work = new Work
			{
				Title = workDto.Title,
				Description = workDto.Description,
				Cost = workDto.Cost,
				UserId = workDto.UserId
			};

			_repository.Save(work);
		}

		public Work GetById(int id)
		{
			var work = _repository.GetById(id);
			return work;
		}

		public List<Work> ShowAllWork()
		{
			return _repository.GetAll();
		}
	}
}