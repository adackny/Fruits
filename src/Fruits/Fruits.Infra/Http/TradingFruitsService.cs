using System.Net.Http.Json;
using Fruits.Application;

namespace Fruits.Infra.Http;

public class TradingFruitsService(HttpClient _client) : ITradingFruitsService
{
    private readonly HttpClient _httpClient = _client;

    public async Task<List<TradingFruit>?> GetFruitsAsync(string name)
    {
        var result = await _httpClient.GetAsync($"api/fruits/{name}");
        var fruits = await result.Content.ReadFromJsonAsync<List<TradingFruit>>();

        return fruits;
    }
}
