using Catalogo.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Catalogo.Infrastructure.Context
{
    // Classe que representa o contexto do banco de dados para a aplicação
    public class ApplicationDbContext : DbContext
    {
        // Construtor que recebe as opções de configuração do DbContext
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        // Conjunto de entidades para a tabela de Categorias
        public DbSet<Categoria> Categorias { get; set; }

        // Conjunto de entidades para a tabela de Produtos
        public DbSet<Produto> Produtos { get; set; }

        // Método chamado durante a criação do modelo do banco de dados
        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Chama o método na classe base (DbContext) para executar configurações padrão
            base.OnModelCreating(builder);

            // Aplica configurações de entidades (mapeamentos) do assembly atual
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
