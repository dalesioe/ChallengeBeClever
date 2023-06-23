using AutoMapper;
using ChallengeBeClever.Application.Interfaces;
using ChallengeBeClever.Application.UseCases.Payment.Post;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChallengeBeClever.Api.Controllers.Payment.Post
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentPostService _paymentService;
        private readonly IMapper _mapper;
        public PaymentController(IPaymentPostService paymentService, IMapper mapper)
        {
            _paymentService = paymentService;
            _mapper = mapper;   
        }

        [HttpPost]
        public async Task<IActionResult> AddPayment([FromBody] PaymentPostInput data)
        {
            var request = _mapper.Map<PaymentPostRequest>(data);
            var result = await _paymentService.AddPayment(request);
            return Ok(result);
        }
    }
}
