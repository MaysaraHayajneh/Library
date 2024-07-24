using System.Security.Claims;

namespace Library.Models
{
	public static class ClaimsStore
	{
		public static List<Claim> Claims {  get; set; }= new List<Claim>()
		{
			new Claim("Create Role","Create Role"),
			new Claim("Edit Role","Edit Role"),
			new Claim("Delete Role","Delete Role"),
			new Claim("Delete User","Delete User"),
			new Claim("Edit User","Edit User"),
			new Claim("Create User","Create User"),

		};
	}
}
