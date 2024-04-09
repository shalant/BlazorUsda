namespace UsdaApi.UsdaInfo;

public interface IUsdaService
{
    Task<List<UsdaData>> GetData();
}
