using FluentMigrator.Runner;
using LivroDeReceitas.Core.Domain.Interfaces.Repositories;
using LivroDeReceitas.Core.Domain.Interfaces.Repositories.Usuario;
using LivroDeReceitas.Core.Shared.Extensions;
using LivroDeRecitas.Adapters.MYSQLServer.Context;
using LivroDeRecitas.Adapters.MYSQLServer.Repositories;
using LivroDeRecitas.Adapters.MYSQLServer.Repositories.Usuario;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace LivroDeRecitas.Adapters.MYSQLServer
{
    public static class BootStrapper
    {
        public static void AddRepositoryDependency(this IServiceCollection services, IConfiguration configuration)
        {

            AddFluentMigrator(services, configuration);
            AddDbContext(services, configuration);

            services.AddScoped<IRepositoryBase, RepositoryBase>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IUsuarioWriteOnyRepository, UsuarioRepository>()
                .AddScoped<IUsuarioReadOnlyRepository, UsuarioRepository>();
        }

        private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
        {
            var versaoServidor = new MySqlServerVersion(new Version(8, 0, 34));
            var connectionString = configuration.GetConnectionStringComplete();

            services.AddDbContext<LivroDeReceitasContext>(options =>
            {
                options.UseMySql(connectionString, versaoServidor);
            });
        }

        private static void AddFluentMigrator(IServiceCollection services, IConfiguration configuration)
        {
            services.AddFluentMigratorCore()
                .ConfigureRunner(c =>
                {
                    c.AddMySql5()
                    .WithGlobalConnectionString(configuration.GetConnectionStringComplete())
                    .ScanIn(Assembly.Load("LivroDeRecitas.Adapters.MYSQLServer"))
                    .For.All();
                });
        }
    }
}
