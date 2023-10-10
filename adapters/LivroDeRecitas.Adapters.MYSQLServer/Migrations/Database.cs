using Dapper;
using MySqlConnector;

namespace LivroDeRecitas.Adapters.MYSQLServer.Migrations
{
    public static class Database
    {
        public static void CreateDatabase(string connectionString, string schemaName)
        {
            using var connection = new MySqlConnection(connectionString);

            var parameters = new
            {
                schemaName
            };

            var result = connection.Query("SELECT * FROM INFORMATION_SCHEMA.SCHEMATA where SCHEMA_NAME = @schemaName", parameters);

            if (!result.Any())
                connection.Execute($"CREATE DATABASE {schemaName}");
        }
    }
}
