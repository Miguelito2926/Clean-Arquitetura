using AutoMapper;
using Catalogo.Application.DTOs;
using Catalogo.Domain.Entities;

namespace Catalogo.Application.Mappings
{
    // Perfil de mapeamento para mapear entidades de domínio para DTOs e vice-versa
    public class DomainToDTOMappingProfile : Profile
    {
        // Construtor do perfil de mapeamento
        public DomainToDTOMappingProfile()
        {
            // Mapeia a entidade Categoria para CategoriaDTO e vice-versa
            CreateMap<Categoria, CategoriaDTO>().ReverseMap();

            // Mapeia a entidade Produto para ProdutoDTO e vice-versa
            CreateMap<Produto, ProdutoDTO>().ReverseMap();
        }
    }
}
