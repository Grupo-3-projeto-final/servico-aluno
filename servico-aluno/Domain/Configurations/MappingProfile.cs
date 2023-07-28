using AutoMapper;
using servico_aluno.Domain.DTO;
using servico_aluno.Domain.Entities;
using servico_aluno.Domain.ModelViews;

namespace servico_aluno.Domain.Configurations;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Student, AlunoPagamentoDto>().ReverseMap();

        CreateMap<Student, StudentResponseDto>();


        CreateMap<StudentRequestDto, Student>()
            .ForMember(s => s.CourseId, options => options.MapFrom(srd => srd.CourseId))
            .ForMember(s => s.Name, options => options.MapFrom(srd =>  srd.Name))
            .ReverseMap();

        CreateMap<Course, CourseRequestDto>().ReverseMap();

    }
}
