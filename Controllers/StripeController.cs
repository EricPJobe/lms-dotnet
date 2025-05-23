// using Microsoft.AspNetCore.Mvc;
// using Stripe;

// namespace lms_server.Controllers;

// public class StripeController : BaseApiController
// {
//     private readonly IStripeService _stripeService;
//     private readonly IMyTokenService _tokenService;

//     public StripeController(IStripeService stripeService, IMyTokenService tokenService)
//     {
//         _stripeService = stripeService;
//         _tokenService = tokenService;
//     }

//     [HttpPost("create-checkout-session")]
//     public async Task<ActionResult<Session>> CreateCheckoutSession([FromBody] CheckoutSessionRequest request)
//     {
//         var session = await _stripeService.CreateCheckoutSession(request);
//         return Ok(session);
//     }
// }