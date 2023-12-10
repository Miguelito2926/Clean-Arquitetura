using Catalogo.Application.DTOs;
using Catalogo.Application.Interfaces;
using Catalogo.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Catalogo.API.Controllers
{
    // Define a rota base para todas as ações deste controlador
    [Route("api/v1/[Controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;

        // Construtor que recebe uma instância do serviço de categoria
        public CategoriasController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        // Obtém todas as categorias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriaDTO>>> Get()
        {
            try
            {
                // Chama o serviço para obter todas as categorias
                var categorias = await _categoriaService.GetCategorias();
                return Ok(categorias); // Retorna as categorias obtidas
            }
            catch
            {
                throw;
            }
        }

        // Obtém uma categoria por ID
        [HttpGet("{id}", Name = "GetCategoria")]
        public async Task<ActionResult<Categoria>> Get(int id)
        {
            // Chama o serviço para obter uma categoria pelo ID
            var categoria = await _categoriaService.GetById(id);

            if (categoria == null)
            {
                return NotFound(); // Retorna NotFound se a categoria não for encontrada
            }
            return Ok(categoria); // Retorna a categoria encontrada
        }

        // Adiciona uma nova categoria
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CategoriaDTO categoriaDto)
        {
            // Verifica a validade do modelo recebido
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Retorna BadRequest se o modelo não for válido
            }

            // Chama o serviço para adicionar a nova categoria
            await _categoriaService.Add(categoriaDto);

            // Retorna um resultado de criação com a rota para obter a categoria recém-criada
            return new CreatedAtRouteResult("GetCategoria",
                new { id = categoriaDto.Id }, categoriaDto);
        }

        // Atualiza uma categoria existente
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] CategoriaDTO categoriaDto)
        {
            // Verifica a validade do modelo recebido
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Retorna BadRequest se o modelo não for válido
            }
            // Verifica se o ID na rota corresponde ao ID no corpo da solicitação
            if (id != categoriaDto.Id)
            {
                return BadRequest(); // Retorna BadRequest se os IDs não corresponderem
            }
            // Chama o serviço para atualizar a categoria
            await _categoriaService.Update(categoriaDto);
            return Ok(categoriaDto); // Retorna a categoria atualizada
        }

        // Exclui uma categoria por ID
        [HttpDelete("{id}")]
        public async Task<ActionResult<Categoria>> Delete(int id)
        {
            // Chama o serviço para obter uma categoria pelo ID
            var categoriaDto = await _categoriaService.GetById(id);
            if (categoriaDto == null)
            {
                return NotFound(); // Retorna NotFound se a categoria não for encontrada
            }
            // Chama o serviço para remover a categoria
            await _categoriaService.Remove(id);
            return Ok(categoriaDto); // Retorna a categoria removida
        }
    }
}
