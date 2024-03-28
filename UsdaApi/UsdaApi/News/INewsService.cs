namespace UsdaApi.News;

public interface INewsService
{
    Task<List<NewsItem>> GetNews();
}
