using Newtonsoft.Json;

namespace FossPTV.Api.Models;

public class Route
{
	[JsonProperty("route_name")]
	public string? Name { get; set; }

	[JsonProperty("route_number")]
	public string? Number { get; set; }

	[JsonProperty("route_type")]
	public int? Type { get; set; }

	[JsonProperty("route_id")]
	public int? Id { get; set; }

	[JsonProperty("route_gtfs_id")]
	public string? GtfsId { get; set; }

	[JsonProperty("route_service_status")]
	public RouteServiceStatus? ServiceStatus { get; set; }
}