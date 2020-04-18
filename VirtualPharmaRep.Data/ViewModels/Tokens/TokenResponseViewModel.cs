namespace VirtualPharmaRep.Data.ViewModels.Tokens
{
	public class TokenResponseViewModel
	{
		public string Token { get; set; }
		public int Expiration { get; set; }
		public string RefreshToken { get; set; }
	}
}