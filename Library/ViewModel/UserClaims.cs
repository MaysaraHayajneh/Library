namespace Library.ViewModel
{
	public class UserClaims
	{
        public UserClaims()
        {
            Claims = new List<ClaimProp>();
        }
        public string UserId { get; set; }
		public List<ClaimProp> Claims { get; set; }
	}
}
