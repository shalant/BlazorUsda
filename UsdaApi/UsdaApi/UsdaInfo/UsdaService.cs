using Microsoft.AspNetCore.DataProtection.KeyManagement;
using System.Text.Json;

namespace UsdaApi.UsdaInfo;

public class UsdaService : IUsdaService
{
    private readonly HttpClient _httpClient;

    const string _baseUrl = "https://quickstats.nass.usda.gov/api/";
    //const string _newsEndpoint = "coins/get-news?pair_ID=1057391&page=1&time_utc_offset=28800&lang_ID=1";
    //const string _usdaEndpoint = "https://quickstats.nass.usda.gov/api/api_GET/?key=C2ADF26B-BD8D-328A-968F-2F175A287144&commodity_desc=CORN&year__GE=2012&state_alpha=VA&format=JSON";
    //const string _usdaEndpoint = "https://quickstats.nass.usda.gov/api/api_GET/?key=C2ADF26B-BD8D-328A-968F-2F175A287144&commodity=CORN&year=2020&metric=acres_planted";
    const string _usdaEndpoint = "https://quickstats.nass.usda.gov/api/api_GET/?key=C2ADF26B-BD8D-328A-968F-2F175A287144&commodity_desc=CORN&statisticcat_desc=AREA%20PLANTED&unit_desc=ACRES&year__GE=2023";
    const string _host = "investing-cryptocurrency-markets.p.rapidapi.com";
    const string _key = "C2ADF26B-BD8D-328A-968F-2F175A287144";

    public UsdaService(HttpClient httpClient) => _httpClient = httpClient;

    public async Task<List<UsdaData>> GetData()
    {
        ConfigureHttpClient();

        var response = await _httpClient.GetAsync(_usdaEndpoint);
        response.EnsureSuccessStatusCode();

        using var stream = await response.Content.ReadAsStreamAsync();

        //var dto = await JsonSerializer.DeserializeAsync<UsdaInfoDto>(stream);
        var dto = await JsonSerializer.DeserializeAsync<List<UsdaInfoDto>>(stream);
        return dto.FirstOrDefault().data.Select(u => new UsdaData
        {
            commodity_desc = u.commodity_desc,
            statisticcat_desc = u.statisticcat_desc,
            year = u.year,
        }).ToList();
        //return dto.ToList();
    }

    private void ConfigureHttpClient()
    {
        //var _key = _config["News:ServiceApiKey"];

        _httpClient.BaseAddress = new Uri(_baseUrl);
        //_httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Host", _host);
        //_httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Key", _key);
    }
}
