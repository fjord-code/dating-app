using Abstractions;
using AutoMapper;
using Entities;

namespace Service.MappingProfiles;

public class EntitiesProfile : Profile
{
    public EntitiesProfile()
    {
        CreateMap<AppUser, AppUserDto>()
            .ReverseMap();
    }
}
