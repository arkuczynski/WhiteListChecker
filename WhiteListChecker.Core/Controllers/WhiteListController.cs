using Microsoft.AspNetCore.Mvc;
using WhiteListChecker.Core.Clients;
using WhiteListChecker.Core.Models;

namespace WhiteListChecker.Core.Controllers
{
	[ApiController]
	[Route("api/search")]
	public class WhiteListController : ControllerBase
	{
		private readonly IWhiteListApiClient _whiteListApiClient;

		public WhiteListController(IWhiteListApiClient whiteListService)
		{
			_whiteListApiClient = whiteListService;
		}

		[HttpGet("nip/{nip}")]
		public async Task<ActionResult<WhiteListApiResponseDto>> GetByNip(string nip)
		{
			try
			{
				var response = await _whiteListApiClient.CheckByNipAsync(nip, DateTime.Today);

				if (response.Result.Subject == null) return NotFound();

				var data = new WhiteListApiResponseDto()
				{
					Name = response.Result.Subject.Name,
					Nip = response.Result.Subject.Nip,
					StatusVat = response.Result.Subject.StatusVat,
					Regon = response.Result.Subject.Regon,
					Pesel = response.Result.Subject.Pesel,
					Krs = response.Result.Subject.Krs,
					ResidenceAddress = response.Result.Subject.ResidenceAddress,
					WorkingAddress = response.Result.Subject.WorkingAddress,
					AccountNumbers = response.Result.Subject.AccountNumbers ?? new List<string>(),
					HasVirtualAccounts = response.Result.Subject.HasVirtualAccounts
				};

				return Ok(data);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

	}
}
