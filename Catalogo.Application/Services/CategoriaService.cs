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
    // Serviço de aplicação para operações relacionadas a categorias
    public class CategoriaService : ICategoriaService
    {
        private ICategoriaRepository _categoryRepository;
        private readonly IMapper _mapper;

        // Construtor do serviço de categoria que recebe o repositório e o mapeador
        public CategoriaService(ICategoriaRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        // Obtém todas as categorias
        public async Task<IEnumerable<CategoriaDTO>> GetCategorias()
        {
            try
            {
                // Chama o repositório para obter entidades de categorias
                var categoriesEntity = await _categoryRepository.GetCategoriasAsync();
                // Mapeia as entidades de categorias para DTOs
                var categoriasDto = _mapper.Map<IEnumerable<CategoriaDTO>>(categoriesEntity);
                return categoriasDto; // Retorna as categorias DTO obtidas
            }
            catch (Exception ex)
            {
                throw; // Trata exceções, você pode querer logar o erro ou realizar outras ações aqui
            }
        }

        // Obtém uma categoria por ID
        public async Task<CategoriaDTO> GetById(int? id)
        {
            // Chama o repositório para obter uma entidade de categoria por ID
            var categoryEntity = await _categoryRepository.GetByIdAsync(id);
            // Mapeia a entidade de categoria para um DTO
            return _mapper.Map<CategoriaDTO>(categoryEntity);
        }

        // Adiciona uma nova categoria
        public async Task Add(CategoriaDTO categoryDto)
        {
            // Mapeia o DTO de categoria para uma entidade de categoria
            var categoryEntity = _mapper.Map<Categoria>(categoryDto);
            // Chama o repositório para criar a nova categoria
            await _categoryRepository.CreateAsync(categoryEntity);
        }

        // Atualiza uma categoria existente
        public async Task Update(CategoriaDTO categoryDto)
        {
            // Mapeia o DTO de categoria para uma entidade de categoria
            var categoryEntity = _mapper.Map<Categoria>(categoryDto);
            // Chama o repositório para atualizar a categoria
            await _categoryRepository.UpdateAsync(categoryEntity);
        }

        // Remove uma categoria por ID
        public async Task Remove(int? id)
        {
            // Chama o repositório para obter uma entidade de categoria por ID
            var categoryEntity = _categoryRepository.GetByIdAsync(id).Result;
            // Chama o repositório para remover a categoria
            await _categoryRepository.RemoveAsync(categoryEntity);
        }
    }
}
