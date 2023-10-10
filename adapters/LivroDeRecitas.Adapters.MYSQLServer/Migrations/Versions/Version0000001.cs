using FluentMigrator;
using LivroDeRecitas.Adapters.MYSQLServer.Migrations.Enum;

namespace LivroDeRecitas.Adapters.MYSQLServer.Migrations.Versions
{
    [Migration((long)VersionType.CriarTabelaUsuario, "Criando tabela de usuarios")]
    public class Version0000001 : Migration
    {
        public override void Down()
        {
            throw new NotImplementedException();
        }

        public override void Up()
        {
            var table = VersionBase.CreateTable(Create.Table("usuarios"));

            table
                .WithColumn("Nome").AsString(60).NotNullable()
                .WithColumn("Email").AsString(100).NotNullable()
                .WithColumn("Telefone").AsString(20).NotNullable()
                .WithColumn("Senha").AsString(200).NotNullable();
        }
    }
}
