using Catalogo.Application.Interfaces;
using Catalogo.Application.Mappings;
using Catalogo.Application.Services;
using Catalogo.Domain.Interfaces;
using Catalogo.Infrastructure.Context;
using Catalogo.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Catalogo.CrossCutting.IoC
{
    // Classe responsável por configurar a injeção de dependência para a camada de infraestrutura da API
    public static class DependencyInjectionAPI
    {
        // Método de extensão para adicionar serviços de infraestrutura à coleção de serviços
        public static IServiceCollection AddInfrastructureAPI(this IServiceCollection services, IConfiguration configuration)
        {
            // Configuração do DbContext para a camada de infraestrutura
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly("Catalogo.Infrastructure")));

            // Adiciona repositórios e serviços à injeção de dependência
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<ICategoriaService, CategoriaService>();

            // Configuração do AutoMapper, indicando o perfil de mapeamento
            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            return services; // Retorna a coleção de serviços configurada
        }
    }
}
