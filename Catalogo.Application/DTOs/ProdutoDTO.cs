using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Catalogo.Application.DTOs
{
    // Data Transfer Object (DTO) para representar um produto
    public class ProdutoDTO
    {
        // Identificador único do produto
        public int Id { get; set; }

        // Nome do produto
        [Required(ErrorMessage = "O nome é obrigatório")] // Atributo de validação para garantir que o nome seja informado
        [MinLength(3)] // Atributo de validação para garantir que o nome tenha pelo menos 3 caracteres
        [MaxLength(100)] // Atributo de validação para garantir que o nome tenha no máximo 100 caracteres
        public string Nome { get; set; }

        // Descrição do produto
        [Required(ErrorMessage = "A descrição é obrigatória")] // Atributo de validação para garantir que a descrição seja informada
        [MinLength(5)] // Atributo de validação para garantir que a descrição tenha pelo menos 5 caracteres
        [MaxLength(200)] // Atributo de validação para garantir que a descrição tenha no máximo 200 caracteres
        public string Descricao { get; set; }

        // Preço do produto
        [Required(ErrorMessage = "Informe o preço")] // Atributo de validação para garantir que o preço seja informado
        [Column(TypeName = "decimal(18,2)")] // Define o tipo da coluna no banco de dados
        [DisplayFormat(DataFormatString = "{0:C2}")] // Formato de exibição para o preço (mostra como moeda)
        [DataType(DataType.Currency)] // Tipo de dados para o preço (moeda)
        public decimal Preco { get; set; }

        // URL da imagem associada ao produto
        [MaxLength(250)] // Atributo de validação para garantir que a URL da imagem tenha no máximo 250 caracteres
        public string ImagemUrl { get; set; }

        // Quantidade em estoque do produto
        [Required(ErrorMessage = "O estoque é obrigatório")] // Atributo de validação para garantir que o estoque seja informado
        [Range(1, 9999)] // Atributo de validação para garantir que o estoque esteja dentro do intervalo especificado
        public int Estoque { get; set; }

        // Data de cadastro do produto
        [Required(ErrorMessage = "Informe a data do cadastro")] // Atributo de validação para garantir que a data de cadastro seja informada
        public DateTime DataCadastro { get; set; }

        // Identificador da categoria associada ao produto
        public int CategoriaId { get; set; }
    }
}
