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
	}
}