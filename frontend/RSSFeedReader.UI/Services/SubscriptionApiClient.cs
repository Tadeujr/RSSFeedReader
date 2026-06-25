using System.Net.Http.Json;
using RSSFeedReader.UI.Models;

namespace RSSFeedReader.UI.Services;

public class SubscriptionApiClient
{
    private readonly HttpClient _httpClient;

    public SubscriptionApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<SubscriptionModel>> GetSubscriptionsAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<SubscriptionModel>>("api/subscriptions") ?? new List<SubscriptionModel>();
    }

    public async Task<HttpResponseMessage> AddSubscriptionAsync(SubscriptionCreateRequestModel request)
    {
        return await _httpClient.PostAsJsonAsync("api/subscriptions", request);
    }
}
