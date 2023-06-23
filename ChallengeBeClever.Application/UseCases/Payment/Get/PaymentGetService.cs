using AutoMapper;
using ChallengeBeClever.Application.Interfaces;
using ChallengeBeClever.Domain.DataTranferObject;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeBeClever.Application.UseCases.Payment.Get
{
    public class PaymentGetService : IPaymentGetService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IMapper _mapper;

        public PaymentGetService(IPaymentRepository paymentRepository, IMapper mapper)
        {
            _paymentRepository = paymentRepository;
            _mapper = mapper;
        }

        public async Task<PaymentGetResponse> ReportPayment(PaymentGetRequest request)
        {
            var requestDto = _mapper.Map<PaymentGetRequestDTO>(request);

            PaymentGetResponse response = new PaymentGetResponse();

            if (requestDto.DateFrom != DateTime.MinValue && requestDto.DateTo != DateTime.MinValue && (requestDto.DateFrom <= requestDto.DateTo))
            {
                response = await _paymentRepository.ReportPayment(requestDto);
            }
            else
            {
                response.Error = "Asegurese que las fechas sean correctas";
            }

            return response;
        }
    }
}
