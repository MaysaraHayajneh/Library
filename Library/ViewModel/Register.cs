using Library.Utilities;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Library.ViewModel
{
	public class Register
	{

		[Required(ErrorMessage = "First name is required.")]
		[MaxLength(10)]
		public string? FirstName { get; set; }
		[Required(ErrorMessage = "Last name is required.")]
		[MaxLength(10)]
		public string? LastName { get; set; }
		[Required(ErrorMessage = "Password is required.")]
		[DataType(DataType.EmailAddress)]
		[ValidateEmailDomain(allowedDomain:"gmail.com",ErrorMessage ="the email domain should be gmail.com")]
		[Remote(action: "IsEmailUsed",controller:"Account")]
		public string? Email { get; set; }
		[DataType(DataType.Password)]
		[Required]
		public string? Password { get; set; }
		[Compare("Password", ErrorMessage = "Password does not match.")]
		[DataType(DataType.Password)]
		public string? ConfirmPassword { get; set; }
		[Required(ErrorMessage = "Address is required.")]
		[DataType(DataType.MultilineText)]
		public string? Address { get; set; }
	}
}
