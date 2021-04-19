using System.ComponentModel.DataAnnotations;

namespace GeoCab.WEB.ViewModels
{
	public class CreateUserViewModel
	{
		[Required]
		public string Username { get; set; }
		[Required]
		public string Email { get; set; }
		[Required]
		[MinLength(8)]
		public string Password { get; set; }
	}
}