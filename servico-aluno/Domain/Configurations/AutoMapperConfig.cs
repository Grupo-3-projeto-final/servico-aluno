using AutoMapper;

namespace servico_aluno.Domain.Configurations;

public static class AutoMapperConfig
{
    public static IMapper ConfigureMappings()
    {
        var mapperConfig = new MapperConfiguration(config =>
        {
            // Registre os perfis de mapeamento aqui
            config.AddProfile<MappingProfile>();
        });

        return mapperConfig.CreateMapper();
    }
}

