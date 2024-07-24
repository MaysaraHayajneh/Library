using System.ComponentModel.DataAnnotations;

namespace Library.Utilities
{
	public class ValidateEmailDomainAttribute:ValidationAttribute
	{
		private readonly string _allowedDomain;

		public ValidateEmailDomainAttribute(string allowedDomain)
        {
			this._allowedDomain = allowedDomain; 
		}
        public override bool IsValid(object? value)
		{
			string[] domain	=value!.ToString()!.Split('@');
			if (string.Equals(domain[1], _allowedDomain, StringComparison.OrdinalIgnoreCase))
			{
				return true;
			}else return false;
		}

	}
}
