using Catalogo.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalogo.Domain.Interfaces
{
    // Interface que define o contrato para o repositório de categorias
    public interface ICategoriaRepository
    {
        // Obtém todas as categorias de forma assíncrona
        Task<IEnumerable<Categoria>> GetCategoriasAsync();

        // Obtém uma categoria por ID de forma assíncrona
        Task<Categoria> GetByIdAsync(int? id);

        // Cria uma nova categoria de forma assíncrona
        Task<Categoria> CreateAsync(Categoria categoria);

        // Atualiza uma categoria de forma assíncrona
        Task<Categoria> UpdateAsync(Categoria categoria);

        // Remove uma categoria de forma assíncrona
        Task<Categoria> RemoveAsync(Categoria categoria);
    }
}
