


namespace Infra.Mappers
{
    using AutoMapper;
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(cfg =>
            {  
                cfg.AddProfile<LivroProfile>();
                
            });

        }

    }
}
