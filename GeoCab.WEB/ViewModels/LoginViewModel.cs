using System.ComponentModel.DataAnnotations;

namespace GeoCab.WEB.ViewModels
{
	public class LoginViewModel
	{
		[Required]
		[MinLength(2)]
		public string Username { get; set; }
		[Required]
		public string Password { get; set; }
	}
}