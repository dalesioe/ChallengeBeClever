using AutoMapper;
using ChallengeBeClever.Application.UseCases.Payment.Post;

namespace ChallengeBeClever.Api.Controllers.Payment.Post
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PaymentPostInput, PaymentPostRequest>()
                .ForMember(x => x.EmployeeId, opt => opt.Ignore());
        }
    }
}
