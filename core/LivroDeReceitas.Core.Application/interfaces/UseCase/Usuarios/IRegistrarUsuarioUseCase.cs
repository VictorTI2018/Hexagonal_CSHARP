using LivroDeReceitas.Core.Application.Request.Usuario;
using LivroDeReceitas.Core.Application.Response.Usuarios;

namespace LivroDeReceitas.Core.Application.interfaces.UseCase.Usuarios
{
    public interface IRegistrarUsuarioUseCase
    {
        Task<UsuarioRegistrarResponse> Execute(UsuarioRegistrarRequest obj);
    }
}
