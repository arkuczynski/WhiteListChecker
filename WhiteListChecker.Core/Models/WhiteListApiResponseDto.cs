namespace WhiteListChecker.Core.Models
{
	public class WhiteListApiResponseDto
	{
		public string Name { get; set; }
		public string Nip { get; set; }
		public string StatusVat { get; set; }
		public string Regon { get; set; }
		public string Pesel { get; set; }
		public string Krs { get; set; }
		public string ResidenceAddress { get; set; }
		public string WorkingAddress { get; set; }

		public List<string> AccountNumbers { get; set; }
		public bool HasVirtualAccounts { get; set; }
	}
}
