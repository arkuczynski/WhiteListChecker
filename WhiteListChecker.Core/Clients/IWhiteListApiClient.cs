using WhiteListChecker.Core.Models;

namespace WhiteListChecker.Core.Clients
{
	public interface IWhiteListApiClient
	{
		Task<MFApiResponseDto> CheckByNipAsync(string nip, DateTime date);
	}
}