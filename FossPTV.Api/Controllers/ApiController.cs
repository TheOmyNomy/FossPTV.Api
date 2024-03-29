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
	[Route("departures/route_type/{route_type}/stop/{stop_id}")]
	public async Task<IActionResult> GetDeparturesAsync(
		[FromRoute(Name = "route_type")] int routeType,
		[FromRoute(Name = "stop_id")] int stopId,
		[FromQuery(Name = "platform_numbers")] int[]? platformNumbers = null,
		[FromQuery(Name = "direction_id")] int? directionId = null,
		[FromQuery(Name = "gtfs")] bool? gtfs = null,
		[FromQuery(Name = "date_utc")] string? dateUtc = null,
		[FromQuery(Name = "max_results")] int? maxResults = null,
		[FromQuery(Name = "include_cancelled")] bool? includeCancelled = null,
		[FromQuery(Name = "look_backwards")] bool? lookBackwards = null,
		[FromQuery(Name = "expand")] string[]? expand = null,
		[FromQuery(Name = "include_geopath")] bool? includeGeopath = null)
	{
		DeparturesResponse? result = await _client.GetDeparturesAsync(
			routeType,
			stopId,
			platformNumbers,
			directionId,
			gtfs,
			dateUtc,
			maxResults,
			includeCancelled,
			lookBackwards,
			expand,
			includeGeopath
		);

		if (result == null)
			return Problem();

		return Ok(result);
	}

	[HttpGet]
	[Route("departures/route_type/{route_type}/stop/{stop_id}/route/{route_id}")]
	public async Task<IActionResult> GetDeparturesAsync(
		[FromRoute(Name = "route_type")] int routeType,
		[FromRoute(Name = "stop_id")] int stopId,
		[FromRoute(Name = "route_id")] int routeId,
		[FromQuery(Name = "direction_id")] int? directionId = null,
		[FromQuery(Name = "gtfs")] bool? gtfs = null,
		[FromQuery(Name = "date_utc")] string? dateUtc = null,
		[FromQuery(Name = "max_results")] int? maxResults = null,
		[FromQuery(Name = "include_cancelled")] bool? includeCancelled = null,
		[FromQuery(Name = "look_backwards")] bool? lookBackwards = null,
		[FromQuery(Name = "expand")] string[]? expand = null,
		[FromQuery(Name = "include_geopath")] bool? includeGeopath = null)
	{
		DeparturesResponse? result = await _client.GetDeparturesAsync(
			routeType,
			stopId,
			routeId,
			directionId,
			gtfs,
			dateUtc,
			maxResults,
			includeCancelled,
			lookBackwards,
			expand,
			includeGeopath
		);

		if (result == null)
			return Problem();

		return Ok(result);
	}

	[HttpGet]
	[Route("directions/route/{route_id}")]
	public async Task<IActionResult> GetDirectionsByRouteAsync(
		[FromRoute(Name = "route_id")] int routeId)
	{
		DirectionsResponse? result = await _client.GetDirectionsByRouteAsync(
			routeId
		);

		if (result == null)
			return Problem();

		return Ok(result);
	}

	[HttpGet]
	[Route("directions/{direction_id}")]
	public async Task<IActionResult> GetDirectionsByDirectionAsync(
		[FromRoute(Name = "direction_id")] int directionId)
	{
		DirectionsResponse? result = await _client.GetDirectionsByDirectionAsync(
			directionId
		);

		if (result == null)
			return Problem();

		return Ok(result);
	}

	[HttpGet]
	[Route("directions/{direction_id}/route_type/{route_type}")]
	public async Task<IActionResult> GetDirectionsAsync(
		[FromRoute(Name = "direction_id")] int directionId,
		[FromRoute(Name = "route_type")] int routeType)
	{
		DirectionsResponse? result = await _client.GetDirectionsAsync(
			directionId,
			routeType
		);

		if (result == null)
			return Problem();

		return Ok(result);
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
	[Route("pattern/run/{run_ref}/route_type/{route_type}")]
	public async Task<IActionResult> GetOutletsAsync(
		[FromRoute(Name = "run_ref")] string runRef,
		[FromRoute(Name = "route_type")] int routeType,
		[FromQuery(Name = "expand")] string[]? expand = null,
		[FromQuery(Name = "stop_id")] int? stopId = null,
		[FromQuery(Name = "date_utc")] string? dateUtc = null,
		[FromQuery(Name = "include_skipped_stops")] bool? includeSkippedStops = null,
		[FromQuery(Name = "include_geopath")] bool? includeGeopath = null)
	{
		PatternResponse? result = await _client.GetPatternAsync(
			runRef,
			routeType,
			expand,
			stopId,
			dateUtc,
			includeSkippedStops,
			includeGeopath
		);

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
	[Route("route_types")]
	public async Task<IActionResult> GetRouteTypeAsync()
	{
		RouteTypesResponse? result = await _client.GetRouteTypesAsync();

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

	[HttpGet]
	[Route("stops/{stop_id}/route_type/{route_type}")]
	public async Task<IActionResult> GetStopAsync(
		[FromRoute(Name = "stop_id")] int stopId,
		[FromRoute(Name = "route_type")] int routeType,
		[FromQuery(Name = "stop_location")] bool? stopLocation = null,
		[FromQuery(Name = "stop_amenities")] bool? stopAmenities = null,
		[FromQuery(Name = "stop_accessibility")] bool? stopAccessibility = null,
		[FromQuery(Name = "stop_contact")] bool? stopContact = null,
		[FromQuery(Name = "stop_ticket")] bool? stopTicket = null,
		[FromQuery(Name = "gtfs")] bool? gtfs = null,
		[FromQuery(Name = "stop_staffing")] bool? stopStaffing = null,
		[FromQuery(Name = "stop_disruptions")] bool? stopDisruptions = null)
	{
		StopResponse? result = await _client.GetStopAsync(
			stopId,
			routeType,
			stopLocation,
			stopAmenities,
			stopAccessibility,
			stopContact,
			stopTicket,
			gtfs,
			stopStaffing,
			stopDisruptions
		);

		if (result == null)
			return Problem();

		return Ok(result);
	}

	[HttpGet]
	[Route("stops/route/{route_id}/route_type/{route_type}")]
	public async Task<IActionResult> GetStopAsync(
		[FromRoute(Name = "route_id")] int routeId,
		[FromRoute(Name = "route_type")] int routeType,
		[FromQuery(Name = "direction_id")] int? directionId = null,
		[FromQuery(Name = "stop_disruptions")] bool? stopDisruptions = null,
		[FromQuery(Name = "include_geopath")] bool? includeGeopath = null,
		[FromQuery(Name = "geopath_utc")] DateTime? geopathUtc = null)
	{
		StopsOnRouteResponse? result = await _client.GetStopAsync(
			routeId,
			routeType,
			directionId,
			stopDisruptions,
			includeGeopath,
			geopathUtc
		);

		if (result == null)
			return Problem();

		return Ok(result);
	}

	[HttpGet]
	[Route("/v3/stops/location/{latitude},{longitude}")]
	public async Task<IActionResult> GetStopAsync(
		[FromRoute(Name = "latitude")] float latitude,
		[FromRoute(Name = "longitude")] float longitude,
		[FromQuery(Name = "route_types")] int[]? routeTypes = null,
		[FromQuery(Name = "max_results")] int? maxResults = null,
		[FromQuery(Name = "max_distance")] double? maxDistance = null,
		[FromQuery(Name = "stop_disruptions")] bool? stopDisruptions = null)
	{
		StopsByDistanceResponse? result = await _client.GetStopAsync(
			latitude,
			longitude,
			routeTypes,
			maxResults,
			maxDistance,
			stopDisruptions
		);

		if (result == null)
			return Problem();

		return Ok(result);
	}
}