using System.Text.Json;
using WhiteListChecker.Web.Models;

namespace WhiteListChecker.Web.Services
{
	public class WhiteListService : IWhiteListService
	{
		private readonly HttpClient _httpClient;

		public WhiteListService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<WhiteListCheckResultVM?> CheckByNipAsync(string nip)
		{
			string url = _httpClient.BaseAddress + $"/search/nip/{nip}";

			var response = await _httpClient.GetAsync(url);

			if (!response.IsSuccessStatusCode)
			{
				return null;
			}

			var json = await response.Content.ReadAsStringAsync();

			var data = JsonSerializer.Deserialize<WhiteListCheckResultVM>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

			return data;
		}
	}
}
