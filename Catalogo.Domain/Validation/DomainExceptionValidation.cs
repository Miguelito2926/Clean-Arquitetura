using System;

namespace Catalogo.Domain.Validation
{
    // Classe de exceção personalizada para validações específicas do domínio
    public class DomainExceptionValidation : Exception
    {
        // Construtor que recebe a mensagem de erro
        public DomainExceptionValidation(string error) : base(error)
        { }

        // Método estático para lançar a exceção quando uma validação falhar
        public static void When(bool hasError, string error)
        {
            // Se houver um erro, lança a exceção personalizada
            if (hasError)
                throw new DomainExceptionValidation(error);
        }
    }
}
