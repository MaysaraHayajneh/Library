using System.ComponentModel.DataAnnotations;

namespace Library.ViewModel
{
	public class Login
	{
		[Required(ErrorMessage = "User Name is required")]
		public string? UserName { get; set; }
		[DataType(DataType.Password)]
		[Required(ErrorMessage = "Password is required")]
		public string? Password { get; set; }
		[Display(Name = "Remember me")]
		public bool RememberMe { get; set; }
	}
}
