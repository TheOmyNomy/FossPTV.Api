using Newtonsoft.Json;

namespace FossPTV.Api.Models;

public class Outlet
{
	[JsonProperty("outlet_distance")]
	public float? Distance { get; set; }

	[JsonProperty("outlet_slid_spid")]
	public string? SlidSpid { get; set; }

	[JsonProperty("outlet_name")]
	public string? Name { get; set; }

	[JsonProperty("outlet_business")]
	public string? Business { get; set; }

	[JsonProperty("outlet_latitude")]
	public float? Latitude { get; set; }

	[JsonProperty("outlet_longitude")]
	public float? Longitude { get; set; }

	[JsonProperty("outlet_suburb")]
	public string? Suburb { get; set; }

	[JsonProperty("outlet_postcode")]
	public int? Postcode { get; set; }

	[JsonProperty("outlet_business_hour_mon")]
	public string? BusinessHourMon { get; set; }

	[JsonProperty("outlet_business_hour_tue")]
	public string? BusinessHourTue { get; set; }

	[JsonProperty("outlet_business_hour_wed")]
	public string? BusinessHourWed { get; set; }

	[JsonProperty("outlet_business_hour_thur")]
	public string? BusinessHourThur { get; set; }

	[JsonProperty("outlet_business_hour_fri")]
	public string? BusinessHourFri { get; set; }

	[JsonProperty("outlet_business_hour_sat")]
	public string? BusinessHourSat { get; set; }

	[JsonProperty("outlet_business_hour_sun")]
	public string? BusinessHourSun { get; set; }

	[JsonProperty("outlet_notes")]
	public string? Notes { get; set; }
}