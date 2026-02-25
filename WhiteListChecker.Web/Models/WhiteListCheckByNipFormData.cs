using System.ComponentModel.DataAnnotations;

namespace WhiteListChecker.Web.Models
{
	public class WhiteListCheckByNipFormData
	{
		[Required(ErrorMessage = "NIP is required.")]
		[StringLength(10, MinimumLength = 10, ErrorMessage = "NIP must have 10 digits.")]
		public string? Nip { get; set; }
		public DateOnly Date { get; set; }
	}
}
