using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
	public class ApplicationUser:IdentityUser
	{

		[PersonalData]
		public string? FirstName { get; set; }
		[PersonalData]
		public string? LastName { get; set; }
		[PersonalData]
		public string? Address { get; set; }
	}
}
