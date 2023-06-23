using AutoMapper;
using ChallengeBeClever.Api.Controllers.Payment.Post;
using ChallengeBeClever.Application.Interfaces;
using ChallengeBeClever.Application.UseCases.Payment.Get;
using ChallengeBeClever.Application.UseCases.Payment.Post;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChallengeBeClever.Api.Controllers.Payment.Get
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentGetService _paymentService;
        private readonly IMapper _mapper;
        public PaymentController(IPaymentGetService paymentService, IMapper mapper)
        {
            _paymentService = paymentService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<PaymentGetResponse> ReportPayment([FromQuery] PaymentGetInput data)
        {
            var request = _mapper.Map<PaymentGetRequest>(data);
            var result = await _paymentService.ReportPayment(request);
            return result;
        }
    }
}
