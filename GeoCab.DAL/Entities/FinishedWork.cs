using System;

namespace GeoCab.DAL.Entities
{
	public class FinishedWork : BaseModel
	{
		public DateTime FinishDate { get; set; }
		
		public long WorkId { get; set; }
		public virtual Work Work { get; set; }
		
		public long EmployeeId { get; set; }
		public virtual Employee Employee { get; set; }
	}
}