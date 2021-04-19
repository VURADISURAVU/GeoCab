using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GeoCab.DAL.Entities
{
	public class User : BaseModel
	{
		[Required]
		public string Username { get; set; }
		[Required]
		public string Email { get; set; }
		[Required]
		public string Password { get; set; }
		
		public virtual List<Work> Works { get; set; }
		public virtual Admin Admin { get; set; }
		public virtual Employee Employee { get; set; }
	}
}