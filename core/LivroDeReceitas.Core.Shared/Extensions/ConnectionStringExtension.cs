using Microsoft.Extensions.Configuration;

namespace LivroDeReceitas.Core.Shared.Extensions
{
    public static class ConnectionStringExtension
    {
        public static string GetConnectionStringExtension (this IConfiguration configurationManager)
        {
            var connection = configurationManager.GetConnectionString("Connection");

            return connection;
        }

        public static string GetSchemaNameExtension(this IConfiguration configuration)
        {
            var schemaName = configuration.GetConnectionString("SchemaName");

            return schemaName;
        }

        public static string GetConnectionStringComplete(this IConfiguration configurationManager)
        {
            var connection = configurationManager.GetConnectionStringExtension();
            var schemaName = configurationManager.GetSchemaNameExtension();

            return $"{connection}Database={schemaName}";
        }
    }
}
