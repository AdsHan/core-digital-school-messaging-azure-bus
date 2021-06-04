using AutoMapper;
using MED.Aluno.Domain.Entities;

namespace MED.Aluno.API.Application.DTO.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AlunoModel, AlunoDTO>().ReverseMap();
            CreateMap<EnderecoModel, EnderecoDTO>().ReverseMap();
            CreateMap<ResponsavelModel, ResponsavelDTO>().ReverseMap();
            CreateMap<ObservacaoModel, ObservacaoDTO>().ReverseMap();
        }
    }
}
