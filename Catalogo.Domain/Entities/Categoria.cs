using Catalogo.Domain.Validation;
using System.Collections.Generic;

namespace Catalogo.Domain.Entities
{
    // Classe que representa uma entidade de categoria no domínio
    public sealed class Categoria : Entity
    {
        // Construtor para criar uma nova categoria
        public Categoria(string nome, string imagemUrl)
        {
            // Chama a validação de domínio para garantir que os parâmetros são válidos
            ValidateDomain(nome, imagemUrl);
        }

        // Construtor para criar uma categoria com um ID específico
        public Categoria(int id, string nome, string imagemUrl)
        {
            // Validação de domínio para garantir que o ID é válido
            DomainExceptionValidation.When(id < 0, "Valor de Id inválido.");

            // Atribui o ID
            Id = id;

            // Chama a validação de domínio para garantir que os parâmetros são válidos
            ValidateDomain(nome, imagemUrl);
        }

        // Propriedade para o nome da categoria
        public string Nome { get; private set; }

        // Propriedade para a URL da imagem associada à categoria
        public string ImagemUrl { get; private set; }

        // Coleção de produtos associados à categoria
        public ICollection<Produto> Produtos { get; set; }

        // Método privado para realizar a validação de domínio
        private void ValidateDomain(string nome, string imagemUrl)
        {
            // Validação de domínio para o nome
            DomainExceptionValidation.When(string.IsNullOrEmpty(nome),
                "Nome inválido. O nome é obrigatório");

            // Validação de domínio para a URL da imagem
            DomainExceptionValidation.When(string.IsNullOrEmpty(imagemUrl),
                "Nome da imagem inválido. O nome é obrigatório");

            // Validação de domínio para o comprimento mínimo do nome
            DomainExceptionValidation.When(nome.Length < 3,
               "O nome deve ter no mínimo 3 caracteres");

            // Validação de domínio para o comprimento mínimo da URL da imagem
            DomainExceptionValidation.When(imagemUrl.Length < 5,
                "Nome da imagem deve ter no mínimo 5 caracteres");

            // Atribui os valores às propriedades se a validação for bem-sucedida
            Nome = nome;
            ImagemUrl = imagemUrl;
        }
    }
}
