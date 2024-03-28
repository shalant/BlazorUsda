
namespace UsdaApi.News;

public class NewsService : INewsService
{
    private readonly HttpClient _httpClient;
    const string _baseUrl = "";
    const string _newsEndpoint = "";
    const string _host = "";
    const string _key = "";

    public NewsService(HttpClient httpClient) => _httpClient = httpClient;

    public Task<List<NewsItem>> GetNews()
    {
        throw new NotImplementedException();
    }
}
