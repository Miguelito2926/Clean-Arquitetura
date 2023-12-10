using Catalogo.Domain.Validation;
using System;

namespace Catalogo.Domain.Entities
{
    // Classe que representa uma entidade de produto no domínio
    public sealed class Produto : Entity
    {
        // Construtor para criar um novo produto
        public Produto(string nome, string descricao, decimal preco, string imagemUrl,
            int estoque, DateTime dataCadastro)
        {
            // Chama a validação de domínio para garantir que os parâmetros são válidos
            ValidateDomain(nome, descricao, preco, imagemUrl, estoque, dataCadastro);
        }

        // Propriedades que representam os atributos do produto
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public decimal Preco { get; private set; }
        public string ImagemUrl { get; private set; }
        public int Estoque { get; private set; }
        public DateTime DataCadastro { get; private set; }

        // Método para atualizar os atributos do produto
        public void Update(string nome, string descricao, decimal preco, string imagemUrl,
            int estoque, DateTime dataCadastro, int categoriaId)
        {
            // Chama a validação de domínio para garantir que os parâmetros são válidos
            ValidateDomain(nome, descricao, preco, imagemUrl, estoque, dataCadastro);
            CategoriaId = categoriaId; // Atualiza o ID da categoria associada ao produto
        }

        // Método privado para realizar a validação de domínio
        private void ValidateDomain(string nome, string descricao, decimal preco, string imagemUrl,
            int estoque, DateTime dataCadastro)
        {
            // Validação de domínio para o nome
            DomainExceptionValidation.When(string.IsNullOrEmpty(nome),
                "Nome inválido. O nome é obrigatório");

            // Validação de domínio para o comprimento mínimo do nome
            DomainExceptionValidation.When(nome.Length < 3,
                "O nome deve ter no mínimo 3 caracteres");

            // Validação de domínio para a descrição
            DomainExceptionValidation.When(string.IsNullOrEmpty(descricao),
                "Descrição inválida. A descrição é obrigatória");

            // Validação de domínio para o comprimento mínimo da descrição
            DomainExceptionValidation.When(descricao.Length < 5,
                "A descrição deve ter no mínimo 5 caracteres");

            // Validação de domínio para o preço
            DomainExceptionValidation.When(preco < 0, "Valor do preço inválido");

            // Validação de domínio para o comprimento máximo da URL da imagem
            DomainExceptionValidation.When(imagemUrl?.Length > 250,
                "O nome da imagem não pode exceder 250 caracteres");

            // Validação de domínio para o estoque
            DomainExceptionValidation.When(estoque < 0, "Estoque inválido");

            // Atribui os valores às propriedades se a validação for bem-sucedida
            Nome = nome;
            Descricao = descricao;
            Preco = preco;
            ImagemUrl = imagemUrl;
            Estoque = estoque;
            DataCadastro = dataCadastro;
        }

        // Propriedade para o ID da categoria associada ao produto
        public int CategoriaId { get; set; }

        // Propriedade de navegação para a categoria associada ao produto
        public Categoria Categoria { get; set; }
    }
}
