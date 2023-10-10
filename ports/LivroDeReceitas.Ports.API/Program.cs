using LivroDeRecitas.Adapters.MYSQLServer.Migrations;
using LivroDeReceitas.Core.Shared.Extensions;
using LivroDeRecitas.Adapters.MYSQLServer.Extensions;
using LivroDeRecitas.Adapters.MYSQLServer;
using LivroDeReceitas.Core.Application.UseCases.Usuario.Registrar;
using LivroDeReceitas.Core.Application.interfaces.UseCase.Usuarios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddRepositoryDependency(builder.Configuration);
builder.Services.AddScoped<IRegistrarUsuarioUseCase, RegistrarUsuarioUseCase>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

UpdateDatabase();

app.Run();

void UpdateDatabase()
{
    var connection = builder.Configuration.GetConnectionStringExtension();
    var schemaName = builder.Configuration.GetSchemaNameExtension();

    Database.CreateDatabase(connection, schemaName);

    app.GenerateMigrations();
}
