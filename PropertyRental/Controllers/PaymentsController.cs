using Microsoft.AspNetCore.Mvc;

namespace PropertyRental.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentsController : ControllerBase
    {
        private readonly PayPalService _payPalService;

        public PaymentsController(PayPalService payPalService)
        {
            _payPalService = payPalService;
        }

        [HttpPost("create")]
        public IActionResult CreatePayment(decimal amount)
        {
            var baseUrl = $"{Request.Scheme}://{Request.Host}";
            var payment = _payPalService.CreatePayment(amount, "USD", $"{baseUrl}/api/payments/success", $"{baseUrl}/api/payments/cancel");

            var approvalUrl = payment.links.FirstOrDefault(x => x.rel == "approval_url")?.href;
            return Ok(new { approvalUrl });
        }

        [HttpGet("success")]
        public IActionResult ExecutePayment(string paymentId, string PayerID)
        {
            var payment = _payPalService.ExecutePayment(paymentId, PayerID);
            if (payment.state == "approved")
            {

                return Ok("Payment successful!");
            }
            return BadRequest("Payment failed.");
        }

        [HttpGet("cancel")]
        public IActionResult Cancel()
        {
            return BadRequest("Payment canceled.");
        }
    }

}
