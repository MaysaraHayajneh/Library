using Library.Utilities;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Library.ViewModel
{
	public class Role
	{
		[Required]
        public string? RoleName { get; set; }

    }
}
