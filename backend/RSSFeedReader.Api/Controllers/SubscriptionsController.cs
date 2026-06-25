using Microsoft.AspNetCore.Mvc;
using RSSFeedReader.Api.Models;
using RSSFeedReader.Api.Services;

namespace RSSFeedReader.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SubscriptionsController : ControllerBase
{
    private readonly SubscriptionService _subscriptionService;

    public SubscriptionsController(SubscriptionService subscriptionService)
    {
        _subscriptionService = subscriptionService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var subscriptions = _subscriptionService.GetAll();
        return Ok(subscriptions);
    }

    [HttpPost]
    public IActionResult Post([FromBody] SubscriptionCreateRequest request)
    {
        try
        {
            _subscriptionService.Add(request);
            return Created(string.Empty, new { url = request.Url.Trim() });
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(new { error = ex.Message });
        }
    }
}
