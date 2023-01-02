using AbandonedMiracle.Api.Dtos.Identity;
using AbandonedMiracle.Api.Dtos.Reports;
using AbandonedMiracle.Api.Entities.Identity;
using AbandonedMiracle.Api.Entities.Reports;
using AutoMapper;

namespace AbandonedMiracle.Api.Common;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<AmUser, UserDto>();
        CreateMap<Report, ReportDto>();
    }
}