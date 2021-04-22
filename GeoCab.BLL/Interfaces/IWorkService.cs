using System.Collections.Generic;
using GeoCab.BLL.DTO;
using GeoCab.DAL.Entities;

namespace GeoCab.BLL.Interfaces
{
	public interface IWorkService
	{
		public void CreateWork(WorkDTO workDto);
		public Work GetById(int id);

		public List<Work> ShowAllWork();
	}
}