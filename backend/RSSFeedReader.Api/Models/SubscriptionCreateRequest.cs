using System.ComponentModel.DataAnnotations;

namespace RSSFeedReader.Api.Models;

public class SubscriptionCreateRequest
{
    [Required]
    [Url]
    public string Url { get; set; } = string.Empty;
}
