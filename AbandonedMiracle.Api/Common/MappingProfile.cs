using AbandonedMiracle.Api.Dtos.Identity;
using AbandonedMiracle.Api.Dtos.Registrations;
using AbandonedMiracle.Api.Entities.Identity;
using AbandonedMiracle.Api.Entities.Registrations;
using AutoMapper;

namespace AbandonedMiracle.Api.Common;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<AmUser, UserDto>();
        CreateMap<Registration, RegistrationDto>();
    }
}