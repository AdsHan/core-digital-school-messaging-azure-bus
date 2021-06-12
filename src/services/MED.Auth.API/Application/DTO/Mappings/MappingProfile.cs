using AutoMapper;
using MED.Auth.Domain.Entities;

namespace MED.Auth.API.Application.DTO.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserModel, UserDTO>().ReverseMap();
        }
    }
}
