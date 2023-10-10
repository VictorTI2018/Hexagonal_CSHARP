using FluentMigrator.Builders.Create.Table;

namespace LivroDeRecitas.Adapters.MYSQLServer.Migrations.Versions
{
    public class VersionBase
    {
        public static ICreateTableWithColumnOrSchemaOrDescriptionSyntax CreateTable(ICreateTableWithColumnOrSchemaOrDescriptionSyntax table)
        {
            table
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("Created_At").AsDateTime().NotNullable()
                .WithColumn("Update_At").AsDateTime().Nullable();
            return table;
        }
    }
}
