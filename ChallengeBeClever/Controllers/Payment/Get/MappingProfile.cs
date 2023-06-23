using AutoMapper;
using ChallengeBeClever.Application.UseCases.Payment.Get;

namespace ChallengeBeClever.Api.Controllers.Payment.Get
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PaymentGetInput, PaymentGetRequest>();
        }
    }
}
