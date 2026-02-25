namespace WhiteListChecker.Core.Models
{
	public class WhiteListCheckResultDto
	{
		public SubjectDto Subject { get; set; }
		public string RequestId { get; set; }
		public string RequestDateTime { get; set; }
	}

}
