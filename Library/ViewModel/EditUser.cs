using System.ComponentModel.DataAnnotations;

namespace Library.ViewModel
{
	public class EditUser
	{
        public EditUser()
        {
			Claims = new List<string>();
			Roles= new List<string>();
        }
        [Required]
		public string? Id { get; set; }
		[Required]
		public string? FirstName { get; set; }
		[Required]
		public string? LastName { get; set; }
		[Required]
		[DataType(DataType.EmailAddress)]
		public string? Email { get; set; }
		[Required]
		public string? UserName { get; set; }
		[Required]
		public string? Address { get; set; }
		public IList<string>? Roles { get; set; }

		public List<string>? Claims { get; set; }
	
	}
}
