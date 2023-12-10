using System.ComponentModel.DataAnnotations;



namespace Catalogo.Application.DTOs
{
    // Data Transfer Object (DTO) para representar uma categoria
    public class CategoriaDTO
    {
        // Identificador único da categoria
        public int Id { get; set; }

        // Nome da categoria
        [Required(ErrorMessage = "Informe o nome da categoria")] // Atributo de validação para garantir que o nome seja informado
        [MinLength(3)] // Atributo de validação para garantir que o nome tenha pelo menos 3 caracteres
        [MaxLength(100)] // Atributo de validação para garantir que o nome tenha no máximo 100 caracteres
        public string Nome { get; set; }

        // URL da imagem associada à categoria
        [Required(ErrorMessage = "Informe o nome da imagem")] // Atributo de validação para garantir que a URL da imagem seja informada
        [MinLength(5)] // Atributo de validação para garantir que a URL da imagem tenha pelo menos 5 caracteres
        [MaxLength(250)] // Atributo de validação para garantir que a URL da imagem tenha no máximo 250 caracteres
        public string ImagemUrl { get; set; }
    }
}
