using FossPTV.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace FossPTV.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ApiController : ControllerBase
{
	private readonly PtvClient _client;

	public ApiController(PtvClient client)
	{
		_client = client;
	}

	[HttpGet]
	[Route("[action]/{term}")]
	public async Task<IActionResult> Search(string term)
	{
		Search? result = await _client.Search(term);

		if (result == null)
			return Problem();

		return Ok(result);
	}
}