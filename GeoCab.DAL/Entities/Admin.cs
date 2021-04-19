using System.ComponentModel.DataAnnotations.Schema;

namespace GeoCab.DAL.Entities
{
	public class Admin : BaseModel
	{
		[ForeignKey("User")]
		public long UserId { get; set; }
		public virtual User User { get; set; }
	}
}