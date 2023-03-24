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
	[Route("routes")]
	public async Task<IActionResult> GetRoutesAsync(
		[FromQuery(Name = "route_types")] int[]? routeTypes = null,
		[FromQuery(Name = "route_name")] string? routeName = null)
	{
		RoutesResponse? result = await _client.GetRoutesAsync(
			routeTypes,
			routeName
		);

		if (result == null)
			return Problem();

		return Ok(result);
	}

	[HttpGet]
	[Route("routes/{route_id}")]
	public async Task<IActionResult> GetRouteAsync(
		[FromRoute(Name = "route_id")] int routeId,
		[FromQuery(Name = "include_geopath")] bool? includeGeopath = null,
		[FromQuery(Name = "geopath_utc")] DateTime? geopathUtc = null)
	{
		RouteResponse? result = await _client.GetRouteAsync(
			routeId,
			includeGeopath,
			geopathUtc
		);

		if (result == null)
			return Problem();

		return Ok(result);
	}

	[HttpGet]
	[Route("runs/route/{route_id}")]
	public async Task<IActionResult> GetRunsAsync(
		[FromRoute(Name = "route_id")] int routeId,
		[FromQuery(Name = "expand")] string[]? expand = null,
		[FromQuery(Name = "date_utc")] DateTime? dateUtc = null)
	{
		RunsResponse? result = await _client.GetRunsAsync(
			routeId,
			expand,
			dateUtc
		);

		if (result == null)
			return Problem();

		return Ok(result);
	}

	[HttpGet]
	[Route("runs/route/{route_id}/route_type/{route_type}")]
	public async Task<IActionResult> GetRunsAsync(
		[FromRoute(Name = "route_id")] int routeId,
		[FromRoute(Name = "route_type")] int routeType,
		[FromQuery(Name = "expand")] string[]? expand = null,
		[FromQuery(Name = "date_utc")] DateTime? dateUtc = null)
	{
		RunsResponse? result = await _client.GetRunsAsync(
			routeId,
			routeType,
			expand,
			dateUtc
		);

		if (result == null)
			return Problem();

		return Ok(result);
	}

	[HttpGet]
	[Route("runs/{run_ref}")]
	public async Task<IActionResult> GetRunsAsync(
		[FromRoute(Name = "run_ref")] string runRef,
		[FromQuery(Name = "expand")] string[]? expand = null,
		[FromQuery(Name = "date_utc")] DateTime? dateUtc = null)
	{
		RunsResponse? result = await _client.GetRunsAsync(
			runRef,
			expand,
			dateUtc
		);

		if (result == null)
			return Problem();

		return Ok(result);
	}

	[HttpGet]
	[Route("runs/{run_ref}/route_type/{route_type}")]
	public async Task<IActionResult> GetRunAsync(
		[FromRoute(Name = "run_ref")] string runRef,
		[FromRoute(Name = "route_type")] int routeType,
		[FromQuery(Name = "expand")] string[]? expand = null,
		[FromQuery(Name = "date_utc")] DateTime? dateUtc = null)
	{
		RunResponse? result = await _client.GetRunAsync(
			runRef,
			routeType,
			expand,
			dateUtc
		);

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