namespace Infra.Mappers
{
    using AutoMapper;
    using DTO;
    using Infra.Context;

    class LivroProfile : Profile
    {

        public LivroProfile()
        {
            CreateMap<livro, LivroDTO>()
            .ForMember(dest => dest.Codigo, map => map.MapFrom(source => source.id))
            .ForMember(dest => dest.Nome, map => map.MapFrom(source => source.nome))
            .ForMember(dest => dest.ISBN, map => map.MapFrom(source => source.isbn))
            .ForMember(dest => dest.Preco, map => map.MapFrom(source => source.preco))
            .ForMember(dest => dest.DataPublicacao, map => map.MapFrom(source => source.dt_publicacao))
            .ForMember(dest => dest.Autor, map => map.MapFrom(source => source.autor))
            .ForMember(dest => dest.CaminhoImg, map => map.MapFrom(source => source.img_capa))

             .AfterMap((dest, source) =>
             {
                
             }).ReverseMap().AfterMap((source, dest) =>
             {
                
             });
        }

    }
}
