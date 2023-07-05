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
	[Route("disruptions")]
	public async Task<IActionResult> GetDisruptionsAsync(
		[FromQuery(Name = "route_types")] int[]? routeTypes = null,
		[FromQuery(Name = "disruption_modes")] int[]? disruptionModes = null,
		[FromQuery(Name = "disruption_status")] string? disruptionStatus = null)
	{
		DisruptionsResponse? result = await _client.GetDisruptionsAsync(
			routeTypes,
			disruptionModes,
			disruptionStatus
		);

		if (result == null)
			return Problem();

		return Ok(result);
	}

	[HttpGet]
	[Route("disruptions/route/{route_id}")]
	public async Task<IActionResult> GetDisruptionsByRouteAsync(
		[FromRoute(Name = "route_id")] int routeId,
		[FromQuery(Name = "disruption_status")] string? disruptionStatus = null)
	{
		DisruptionsResponse? result = await _client.GetDisruptionsByRouteAsync(
			routeId,
			disruptionStatus
		);

		if (result == null)
			return Problem();

		return Ok(result);
	}

	[HttpGet]
	[Route("disruptions/route/{route_id}/stop/{stop_id}")]
	public async Task<IActionResult> GetDisruptionsAsync(
		[FromRoute(Name = "route_id")] int routeId,
		[FromRoute(Name = "stop_id")] int stopId,
		[FromQuery(Name = "disruption_status")] string? disruptionStatus = null)
	{
		DisruptionsResponse? result = await _client.GetDisruptionsAsync(
			routeId,
			stopId,
			disruptionStatus
		);

		if (result == null)
			return Problem();

		return Ok(result);
	}

	[HttpGet]
	[Route("disruptions/stop/{stop_id}")]
	public async Task<IActionResult> GetDisruptionsByStopAsync(
		[FromRoute(Name = "stop_id")] int stopId,
		[FromQuery(Name = "disruption_status")] string? disruptionStatus = null)
	{
		DisruptionsResponse? result = await _client.GetDisruptionsByStopAsync(
			stopId,
			disruptionStatus
		);

		if (result == null)
			return Problem();

		return Ok(result);
	}

	[HttpGet]
	[Route("disruptions/{disruption_id}")]
	public async Task<IActionResult> GetDisruptionAsync(
		[FromRoute(Name = "disruption_id")] int disruptionId)
	{
		DisruptionResponse? result = await _client.GetDisruptionAsync(
			disruptionId
		);

		if (result == null)
			return Problem();

		return Ok(result);
	}

	[HttpGet]
	[Route("disruptions/modes")]
	public async Task<IActionResult> GetDisruptionModesAsync()
	{
		DisruptionModesResponse? result = await _client.GetDisruptionModesAsync();

		if (result == null)
			return Problem();

		return Ok(result);
	}

	[HttpGet]
	[Route("outlets")]
	public async Task<IActionResult> GetOutletsAsync(
		[FromQuery(Name = "max_results")] int? maxResults = null)
	{
		OutletsResponse? result = await _client.GetOutletsAsync(
			maxResults
		);

		if (result == null)
			return Problem();

		return Ok(result);
	}

	[HttpGet]
	[Route("outlets/location/{latitude},{longitude}")]
	public async Task<IActionResult> GetOutletsAsync(
		[FromRoute(Name = "latitude")] float latitude,
		[FromRoute(Name = "longitude")] float longitude,
		[FromQuery(Name = "max_distance")] double? maxDistance = null,
		[FromQuery(Name = "max_results")] int? maxResults = null)
	{
		OutletsResponse? result = await _client.GetOutletsAsync(
			latitude,
			longitude,
			maxDistance,
			maxResults
		);

		if (result == null)
			return Problem();

		return Ok(result);
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