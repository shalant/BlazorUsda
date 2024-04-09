
using Microsoft.AspNetCore.Components;
using System.Text.Json;

namespace UsdaApi.News;

public class NewsService : INewsService
{
    //private readonly IConfiguration _config;

    //public NewsService(IConfiguration config)
    //{
    //    _config = config;
    //}

    private readonly HttpClient _httpClient;
    //TODO: hide these in a config file, try not to put these on GH
    const string _baseUrl = "https://investing-cryptocurrency-markets.p.rapidapi.com";
    const string _newsEndpoint = "coins/get-news?pair_ID=1057391&page=1&time_utc_offset=28800&lang_ID=1";
    const string _host = "investing-cryptocurrency-markets.p.rapidapi.com";
    const string _key = "d0a001874dmshb993809de6fe686p13f52cjsn2899437b8f3e";

    public NewsService(HttpClient httpClient) => _httpClient = httpClient;

    public async Task<List<NewsItem>> GetNews()
    {
        ConfigureHttpClient();

        var response = await _httpClient.GetAsync(_newsEndpoint);
        response.EnsureSuccessStatusCode();

        using var stream = await response.Content.ReadAsStreamAsync();

        var dto = await JsonSerializer.DeserializeAsync<NewsDto>(stream);
        return dto.data.FirstOrDefault().screen_data.news.Select(n => new NewsItem
        {
            Headline = n.HEADLINE,
            Body = (MarkupString)n.BODY,
            ImageUrl = n.related_image
        }).ToList();
    }

    private void ConfigureHttpClient()
    {
        //var _key = _config["News:ServiceApiKey"];

        _httpClient.BaseAddress = new Uri(_baseUrl);
        _httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Host", _host);
        _httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Key", _key);
    }
}
