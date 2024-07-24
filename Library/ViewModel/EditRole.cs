using System.ComponentModel.DataAnnotations;

namespace Library.ViewModel
{
	public class EditRole
	{
        public EditRole()
        {
            Users = new List<string>();
        }
        [Required]
        public string? Id { get; set; }
		[Required(ErrorMessage ="Role name is required")]
		public string? RoleName { get; set; }	
		public List<string>? Users { get; set; }
    }
}
