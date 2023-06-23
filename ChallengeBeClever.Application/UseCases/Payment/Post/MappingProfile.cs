using AutoMapper;
using ChallengeBeClever.Application.UseCases.Payment.Post;
using ChallengeBeClever.Domain.DataTranferObject;

namespace ChallengeBeClever.Application.UseCases.Payment.Post
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PaymentPostRequest, PaymentPostRequestDTO>();
        }
    }
}
