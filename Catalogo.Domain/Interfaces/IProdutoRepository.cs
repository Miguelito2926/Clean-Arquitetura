using Catalogo.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalogo.Domain.Interfaces
{
    // Interface que define o contrato para o repositório de produtos
    public interface IProdutoRepository
    {
        // Obtém todos os produtos de forma assíncrona
        Task<IEnumerable<Produto>> GetProdutosAsync();

        // Obtém um produto por ID de forma assíncrona
        Task<Produto> GetByIdAsync(int? id);

        // Cria um novo produto de forma assíncrona
        Task<Produto> CreateAsync(Produto produto);

        // Atualiza um produto de forma assíncrona
        Task<Produto> UpdateAsync(Produto produto);

        // Remove um produto de forma assíncrona
        Task<Produto> RemoveAsync(Produto produto);
    }
}
