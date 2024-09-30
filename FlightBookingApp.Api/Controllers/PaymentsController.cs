using FlightBookingApp.Services.Interfaces;
using FlightBookingApp.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FlightBookingApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentsController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost("process")]
        public async Task<ActionResult> ProcessPayment([FromBody] Payment model)
        {
            var payment = new Payment
            {
                BookingId = model.BookingId,
                Amount = model.Amount,
                PaymentDate = model.PaymentDate,
                PaymentMode = model.PaymentMode,
                PaymentStatus = model.PaymentStatus
            };

            var result = await _paymentService.ProcessPaymentAsync(payment);
            if (result)
            {
                return Ok();
            }
            return BadRequest("Payment processing failed.");
        }

        [HttpPost("apply-offer")]
        public async Task<ActionResult> ApplyOffer([FromBody] Offer model)
        {
            var result = await _paymentService.ApplyOfferAsync(model.Id, model.OfferCode);
            if (result)
            {
                return Ok();
            }
            return BadRequest("Applying offer failed.");
        }

        [HttpPost("add-insurance")]
        public async Task<ActionResult> AddInsurance([FromBody] TravelInsurance model)
        {
            var insurance = new TravelInsurance
            {
                InsuranceProvider = model.InsuranceProvider,
                InsuranceAmount = model.InsuranceAmount,
                PolicyDetails = model.PolicyDetails
            };

            var result = await _paymentService.AddInsuranceAsync(model.Id, insurance);
            if (result)
            {
                return Ok();
            }
            return BadRequest("Adding insurance failed.");
        }
    }
}