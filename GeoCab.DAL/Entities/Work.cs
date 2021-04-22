using System.ComponentModel.DataAnnotations;

namespace GeoCab.DAL.Entities
{
	public class Work : BaseModel
	{
		[Required]
		public string Title { get; set; }
		[Required]
		public string Description { get; set; }
		[Required]
		public float Cost { get; set; }
		
		public long UserId { get; set; }
		public virtual User User { get; set; }
		
		public long EmployeeId { get; set; }
		public virtual Employee Employee { get; set; }
		
		public virtual FinishedWork FinishedWork { get; set; }
	}
}