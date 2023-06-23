using AutoMapper;
using ChallengeBeClever.Application.Interfaces;
using ChallengeBeClever.Domain.DataTranferObject;
using Microsoft.AspNetCore.Http;

namespace ChallengeBeClever.Application.UseCases.Payment.Post
{
    public class PaymentPostService : IPaymentPostService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IMapper _mapper;

        public PaymentPostService(IPaymentRepository paymentRepository, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            _paymentRepository = paymentRepository;
            _contextAccessor = httpContextAccessor;
            _mapper = mapper;
        }

        public async Task<bool> AddPayment(PaymentPostRequest data)
        {
            var user = _contextAccessor.HttpContext?.User.FindFirst("UserId");
            if (user == null)
            {
                return false;
            }
            data.EmployeeId = Convert.ToInt32(user.Value);

            var dto = _mapper.Map<PaymentPostRequestDTO>(data);

            if (data.RegisterType != null && data.BusinessLocation != null && data.Date != DateTime.MinValue)
            {
                var result =await _paymentRepository.AddPayment(dto);
                return result;
            }

            return false;
        }
    }
}
