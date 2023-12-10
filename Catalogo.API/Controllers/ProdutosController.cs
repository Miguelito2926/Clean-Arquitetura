using Catalogo.Application.DTOs;
using Catalogo.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Catalogo.API.Controllers
{
    // Controlador para lidar com operações relacionadas a produtos
    [Route("api/v1/[Controller]")]
    [ApiController]
    public class ProdutosController : Controller
    {
        private readonly IProdutoService _produtoService;

        // Construtor que recebe uma instância do serviço de produto
        public ProdutosController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        // Obtém todos os produtos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoDTO>>> Get()
        {
            // Chama o serviço para obter todos os produtos
            var produtos = await _produtoService.GetProdutos();
            return Ok(produtos); // Retorna os produtos obtidos
        }

        // Obtém um produto por ID
        [HttpGet("{id}", Name = "GetProduto")]
        public async Task<ActionResult<ProdutoDTO>> Get(int id)
        {
            // Chama o serviço para obter um produto pelo ID
            var produto = await _produtoService.GetById(id);

            if (produto == null)
            {
                return NotFound(); // Retorna NotFound se o produto não for encontrado
            }
            return Ok(produto); // Retorna o produto encontrado
        }

        // Adiciona um novo produto
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProdutoDTO produtoDto)
        {
            // Verifica a validade do modelo recebido
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Retorna BadRequest se o modelo não for válido
            }

            // Chama o serviço para adicionar o novo produto
            await _produtoService.Add(produtoDto);

            // Retorna um resultado de criação com a rota para obter o produto recém-criado
            return new CreatedAtRouteResult("GetProduto",
                new { id = produtoDto.Id }, produtoDto);
        }

        // Atualiza um produto existente
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ProdutoDTO produtoDto)
        {
            // Verifica se o ID na rota corresponde ao ID no corpo da solicitação
            if (id != produtoDto.Id)
            {
                return BadRequest(); // Retorna BadRequest se os IDs não corresponderem
            }

            // Chama o serviço para atualizar o produto
            await _produtoService.Update(produtoDto);
            return Ok(produtoDto); // Retorna o produto atualizado
        }

        // Exclui um produto por ID
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProdutoDTO>> Delete(int id)
        {
            // Chama o serviço para obter um produto pelo ID
            var produtoDto = await _produtoService.GetById(id);
            if (produtoDto == null)
            {
                return NotFound(); // Retorna NotFound se o produto não for encontrado
            }

            // Chama o serviço para remover o produto
            await _produtoService.Remove(id);
            return Ok(produtoDto); // Retorna o produto removido
        }
    }
}
