using AutoMapper;
using ChallengeBeClever.Application.UseCases.Payment.Post;
using ChallengeBeClever.Domain.DataTranferObject;

namespace ChallengeBeClever.Application.UseCases.Payment.Get
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PaymentGetRequest, PaymentGetRequestDTO>();
        }
    }
}
