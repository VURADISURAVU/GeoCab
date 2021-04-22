using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeoCab.DAL.Entities
{
	public class Employee : BaseModel
	{
		public int Experience { get; set; }
		public int CountSuccessWork { get; set; }
		public float Rating { get; set; }
		
		[ForeignKey("User")]
		public long UserId { get; set; }
		public virtual User User { get; set; }
		
		[ForeignKey("Tool")]
		public long ToolId { get; set; }
		public virtual Tool Tool { get; set; }
		
		public virtual List<Work> Work { get; set; }
		public virtual List<FinishedWork> FinishedWork { get; set; }
	}
}