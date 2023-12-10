using Catalogo.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalogo.Application.Interfaces
{
    // Interface para o serviço de categoria, define operações relacionadas a categorias
    public interface ICategoriaService
    {
        // Obtém todas as categorias
        Task<IEnumerable<CategoriaDTO>> GetCategorias();

        // Obtém uma categoria por ID
        Task<CategoriaDTO> GetById(int? id);

        // Adiciona uma nova categoria
        Task Add(CategoriaDTO categoriaDto);

        // Atualiza uma categoria existente
        Task Update(CategoriaDTO categoriaDto);

        // Remove uma categoria por ID
        Task Remove(int? id);
    }
}
