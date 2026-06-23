using UHB.Application.Dtos.Authentication.User;
using UHB.Domain.Entities;
using UHB.Domain.Mappings;

namespace UHB.Extensions.ServiceHandlers.Extensions;

public class RegisterProfile : MappingProfile<UserDomain, RegisterRequest>
{
    public RegisterProfile() : base()
    {
        CreateMap<UserDomain, RegisterRequest>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.PhoneNumber));

        CreateMap<RegisterRequest, UserDomain>()
            .ForMember(dest => dest.PasswordHash, opt => opt.Ignore())
            .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.UserName));
    }
}
