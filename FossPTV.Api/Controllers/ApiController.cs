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
	[Route("route_types")]
	public async Task<IActionResult> GetRouteTypeAsync()
	{
		RouteTypesResponse? result = await _client.GetRouteTypesAsync();

		if (result == null)
			return Problem();

		return Ok(result);
	}

	[HttpGet]
	[Route("search/{term}")]
	public async Task<IActionResult> GetSearchResultAsync(string term)
	{
		SearchResponse? result = await _client.GetSearchAsync(term);

		if (result == null)
			return Problem();

		return Ok(result);
	}
}