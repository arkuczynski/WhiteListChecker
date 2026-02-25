using System.Text.Json;
using WhiteListChecker.Core.Models;

namespace WhiteListChecker.Core.Clients
{
	public class WhiteListApiClient : IWhiteListApiClient
	{
		private readonly HttpClient _httpClient;

		public WhiteListApiClient(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<MFApiResponseDto> CheckByNipAsync(string nip, DateTime date)
		{
			string formattedDate = date.ToString("yyyy-MM-dd");
			string url = _httpClient.BaseAddress + $"/search/nip/{nip}?date={formattedDate}";

			var response = await _httpClient.GetAsync(url);

			response.EnsureSuccessStatusCode();

			var json = await response.Content.ReadAsStringAsync();

			var result = JsonSerializer.Deserialize<MFApiResponseDto>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

			return result;
		}
	}

}
