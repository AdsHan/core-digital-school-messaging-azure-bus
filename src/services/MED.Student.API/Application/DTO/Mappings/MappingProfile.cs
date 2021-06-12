using AutoMapper;
using MED.Student.Domain.Entities;

namespace MED.Student.API.Application.DTO.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<StudentModel, StudentDTO>().ReverseMap();
            CreateMap<AdressModel, AdressDTO>().ReverseMap();
            CreateMap<GuardianModel, GuardianDTO>().ReverseMap();
            CreateMap<NoteModel, NoteDTO>().ReverseMap();
        }
    }
}
