using AbandonedMiracle.Api.Dtos.Identity;
using AbandonedMiracle.Api.Entities.Identity;
using AutoMapper;

namespace AbandonedMiracle.Api.Common;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<AmUser, UserDto>();
    }
}