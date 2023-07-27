using AutoMapper;
using servico_aluno.Domain.ModelViews;

namespace servico_aluno.Domain.Configurations;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Aluno, AlunoPagamento>().ReverseMap();
    }
}
