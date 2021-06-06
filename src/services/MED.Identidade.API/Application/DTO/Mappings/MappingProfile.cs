using AutoMapper;
using MED.Identidade.Domain.Entities;

namespace MED.Identidade.API.Application.DTO.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UsuarioModel, UsuarioDTO>().ReverseMap();
        }
    }
}
