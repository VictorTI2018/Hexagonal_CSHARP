using LivroDeReceitas.Core.Application.interfaces.UseCase.Usuarios;
using LivroDeReceitas.Core.Application.Request.Usuario;
using LivroDeReceitas.Core.Application.Response.Usuarios;
using LivroDeReceitas.Core.Application.Validators.Usuario;
using LivroDeReceitas.Core.Domain.Entities.Usuario;
using LivroDeReceitas.Core.Domain.Interfaces.Repositories;
using LivroDeReceitas.Core.Domain.Interfaces.Repositories.Usuario;

namespace LivroDeReceitas.Core.Application.UseCases.Usuario.Registrar
{
    public class RegistrarUsuarioUseCase : IRegistrarUsuarioUseCase
    {
        private readonly IUsuarioWriteOnyRepository _usuarioWriteOnyRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RegistrarUsuarioUseCase(IUsuarioWriteOnyRepository usuarioWriteOnyRepository,
            IUnitOfWork unitOfWork)
        {
            _usuarioWriteOnyRepository = usuarioWriteOnyRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<UsuarioRegistrarResponse> Execute(UsuarioRegistrarRequest obj)
        {
            UsuarioRegistrarResponse response = new()
            {
                Status = false
            };

            UsuarioRegistrarValidator validator = new();
            var result = validator.Validate(obj);

            if (!result.IsValid)
            {

                response.Messages.AddRange(result.Errors.Select(e => e.ErrorMessage));

                return response;
            }

            response.Status = true;

            UsuarioEntity usuario = new(obj.Nome, obj.Email, obj.Telefone, obj.Senha);

            await _usuarioWriteOnyRepository.SaveAsync(usuario);
            await _unitOfWork.Commit();

            return response;

        }
    }
}
