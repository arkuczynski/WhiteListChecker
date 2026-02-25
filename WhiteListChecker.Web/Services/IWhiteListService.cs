using WhiteListChecker.Web.Models;

namespace WhiteListChecker.Web.Services
{
	public interface IWhiteListService
	{
		Task<WhiteListCheckResultVM?> CheckByNipAsync(string nip);
	}
}
