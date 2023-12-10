using AutoMapper;
using Catalogo.Application.DTOs;
using Catalogo.Application.Interfaces;
using Catalogo.Domain.Entities;
using Catalogo.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalogo.Application.Services
{
    // Serviço de aplicação para operações relacionadas a produtos
    public class ProdutoService : IProdutoService
    {
        private IProdutoRepository _productRepository;
        private readonly IMapper _mapper;

        // Construtor do serviço de produto que recebe o repositório e o mapeador
        public ProdutoService(IMapper mapper, IProdutoRepository productRepository)
        {
            // Garante que o repositório de produtos seja fornecido, senão lança uma exceção
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _mapper = mapper;
        }

        // Obtém todos os produtos
        public async Task<IEnumerable<ProdutoDTO>> GetProdutos()
        {
            // Chama o repositório para obter entidades de produtos
            var productsEntity = await _productRepository.GetProdutosAsync();
            // Mapeia as entidades de produtos para DTOs
            return _mapper.Map<IEnumerable<ProdutoDTO>>(productsEntity);
        }

        // Obtém um produto por ID
        public async Task<ProdutoDTO> GetById(int? id)
        {
            // Chama o repositório para obter uma entidade de produto por ID
            var productEntity = await _productRepository.GetByIdAsync(id);
            // Mapeia a entidade de produto para um DTO
            return _mapper.Map<ProdutoDTO>(productEntity);
        }

        // Adiciona um novo produto
        public async Task Add(ProdutoDTO productDto)
        {
            // Mapeia o DTO de produto para uma entidade de produto
            var productEntity = _mapper.Map<Produto>(productDto);
            // Chama o repositório para criar o novo produto
            await _productRepository.CreateAsync(productEntity);
        }

        // Atualiza um produto existente
        public async Task Update(ProdutoDTO productDto)
        {
            // Mapeia o DTO de produto para uma entidade de produto
            var productEntity = _mapper.Map<Produto>(productDto);
            // Chama o repositório para atualizar o produto
            await _productRepository.UpdateAsync(productEntity);
        }

        // Remove um produto por ID
        public async Task Remove(int? id)
        {
            // Chama o repositório para obter uma entidade de produto por ID
            var productEntity = _productRepository.GetByIdAsync(id).Result;
            // Chama o repositório para remover o produto
            await _productRepository.RemoveAsync(productEntity);
        }
    }
}
