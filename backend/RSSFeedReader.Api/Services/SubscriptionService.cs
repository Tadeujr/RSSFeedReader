using System.Collections.Concurrent;
using System.Linq;
using System.Text.RegularExpressions;
using RSSFeedReader.Api.Models;

namespace RSSFeedReader.Api.Services;

public class SubscriptionService
{
    private static readonly ConcurrentBag<Subscription> Subscriptions = new();
    private static readonly Regex UrlPattern = new(@"^https?://.+", RegexOptions.Compiled | RegexOptions.IgnoreCase);

    public IEnumerable<Subscription> GetAll()
    {
        return Subscriptions.ToArray();
    }

    public void Add(SubscriptionCreateRequest request)
    {
        ValidateRequest(request);
        var normalizedUrl = request.Url.Trim();

        if (Subscriptions.Any(x => string.Equals(x.Url, normalizedUrl, StringComparison.OrdinalIgnoreCase)))
        {
            throw new InvalidOperationException("A assinatura já existe.");
        }

        Subscriptions.Add(new Subscription { Url = normalizedUrl });
    }

    private static void ValidateRequest(SubscriptionCreateRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Url))
        {
            throw new ArgumentException("A URL não pode estar vazia.");
        }

        var url = request.Url.Trim();
        if (!UrlPattern.IsMatch(url))
        {
            throw new ArgumentException("A URL informada não é válida.");
        }
    }
}
