using Microsoft.AspNetCore.Mvc;
using PtvSharp;
using PtvSharp.Models;

namespace FossPTV.Api.Controllers;

[ApiController]
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
		SearchResult? result = await _client.GetSearchResultAsync(term);

		if (result == null)
			return Problem();

		return Ok(result);
	}
}