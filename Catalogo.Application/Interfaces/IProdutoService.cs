using Catalogo.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalogo.Application.Interfaces
{
    // Interface para o serviço de produto, define operações relacionadas a produtos
    public interface IProdutoService
    {
        // Obtém todos os produtos
        Task<IEnumerable<ProdutoDTO>> GetProdutos();

        // Obtém um produto por ID
        Task<ProdutoDTO> GetById(int? id);

        // Adiciona um novo produto
        Task Add(ProdutoDTO produtoDto);

        // Atualiza um produto existente
        Task Update(ProdutoDTO produtoDto);

        // Remove um produto por ID
        Task Remove(int? id);
    }
}
