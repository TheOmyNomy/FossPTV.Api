using Newtonsoft.Json;

namespace FossPTV.Api.Models;

public class Stop
{
	[JsonProperty("stop_distance")]
	public float? Distance { get; set; }

	[JsonProperty("stop_suburb")]
	public string? Suburb { get; set; }

	[JsonProperty("route_type")]
	public int? RouteType { get; set; }

	[JsonProperty("routes")]
	public Route[]? Routes { get; set; }

	[JsonProperty("stop_latitude")]
	public float? Latitude { get; set; }

	[JsonProperty("stop_longitude")]
	public float? Longitude { get; set; }

	[JsonProperty("sequence")]
	public int? Sequence { get; set; }

	[JsonProperty("stop_id")]
	public int? Id { get; set; }

	[JsonProperty("stop_name")]
	public string? Name { get; set; }

	[JsonProperty("stop_landmark")]
	public string? Landmark { get; set; }
}