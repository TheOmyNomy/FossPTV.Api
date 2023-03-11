using System.Security.Cryptography;
using System.Text;
using FossPTV.Api.Models;
using Newtonsoft.Json;

namespace FossPTV.Api;

public class PtvClient
{
	private const string BaseUrl = "https://timetableapi.ptv.vic.gov.au";

	public const string VersionEndpoint = "/v3";
	public const string SearchEndpoint = VersionEndpoint + "/search/{0}";

	private static readonly HttpClient Client = new HttpClient
	{
		BaseAddress = new Uri(BaseUrl)
	};

	private readonly int _developerId;
	private readonly string _developerKey;

	public PtvClient(int developerId, string developerKey)
	{
		_developerId = developerId;
		_developerKey = developerKey;
	}

	public async Task<Search?> Search(string term)
	{
		string endpoint = ConstructEndpoint(SearchEndpoint, term);
		string url = ConstructUrl(endpoint);

		return await GetAsync<Search>(url);
	}

	private async Task<T?> GetAsync<T>(string url)
	{
		string contents = await Client.GetStringAsync(url);
		return JsonConvert.DeserializeObject<T>(contents);
	}

	private string ConstructEndpoint(string endpoint, params object[] arguments)
	{
		for (int i = 0; i < arguments.Length; i++)
		{
			string? value = arguments[i].ToString();

			if (!string.IsNullOrWhiteSpace(value))
				arguments[i] = Uri.EscapeDataString(value);
		}

		return string.Format(endpoint, arguments);
	}

	private string ConstructUrl(string endpoint, Dictionary<string, string>? parameters = null)
	{
		StringBuilder urlBuilder = new StringBuilder(endpoint);
		urlBuilder.Append("?devid=").Append(_developerId);

		if (parameters != null)
		{
			foreach (var parameter in parameters)
			{
				urlBuilder.Append("&").Append(parameter.Key).Append("=");

				if (!string.IsNullOrWhiteSpace(parameter.Value))
				{
					string value = Uri.EscapeDataString(parameter.Value);
					urlBuilder.Append(value);
				}
			}
		}

		byte[] keyBytes = Encoding.ASCII.GetBytes(_developerKey);

		string url = urlBuilder.ToString();
		byte[] urlBytes = Encoding.ASCII.GetBytes(url);

		byte[] tokenBytes = new HMACSHA1(keyBytes).ComputeHash(urlBytes);

		StringBuilder signatureBuilder = new StringBuilder();

		Array.ForEach(tokenBytes, tokenByte =>
		{
			string value = tokenByte.ToString("X2");
			signatureBuilder.Append(value);
		});

		string signature = signatureBuilder.ToString();
		urlBuilder.Append("&signature=").Append(signature);

		return urlBuilder.ToString();
	}
}