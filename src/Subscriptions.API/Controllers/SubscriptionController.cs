using Microsoft.AspNetCore.Mvc;
using Subscriptions.API.Interfaces;
using Subscriptions.API.Models;
using System.Net.Mime;

namespace Subscriptions.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubscriptionController : ControllerBase
    {
        private readonly ISubscriptionService _subscriptionService;

        public SubscriptionController(ISubscriptionService subscriptionService)
        {
            _subscriptionService = subscriptionService;
        }

        [HttpPost("add-subscription")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(AddSubscriptionResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddSubscription([FromBody] AddSubscriptionRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var data = await _subscriptionService.AddSubscription(request);

            return data != null ? Ok(data) : NotFound();
        }
    }
}
