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
	public async Task<IActionResult> GetSearchAsync(
		[FromRoute(Name = "term")] string term,
		[FromQuery(Name = "route_types")] int[]? routeTypes = null,
		[FromQuery(Name = "latitude")] float? latitude = null,
		[FromQuery(Name = "longitude")] float? longitude = null,
		[FromQuery(Name = "max_distance")] float? maxDistance = null,
		[FromQuery(Name = "include_outlets")] bool? includeOutlets = null,
		[FromQuery(Name = "match_stop_by_suburb")] bool? matchStopBySuburb = null,
		[FromQuery(Name = "match_route_by_suburb")] bool? matchRouteBySuburb = null,
		[FromQuery(Name = "match_stop_by_gtfs_stop_id")] bool? matchStopByGtfsStopId = null)
	{
		SearchResponse? result = await _client.GetSearchAsync(
			term,
			routeTypes,
			latitude,
			longitude,
			maxDistance,
			includeOutlets,
			matchStopBySuburb,
			matchRouteBySuburb,
			matchStopByGtfsStopId
		);

		if (result == null)
			return Problem();

		return Ok(result);
	}
}