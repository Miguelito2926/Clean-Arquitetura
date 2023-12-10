namespace Catalogo.Domain.Entities
{
    // Classe abstrata que serve como base para todas as entidades do domínio
    public abstract class Entity
    {
        // Propriedade protegida que representa a identidade da entidade
        public int Id { get; protected set; }
    }
}
