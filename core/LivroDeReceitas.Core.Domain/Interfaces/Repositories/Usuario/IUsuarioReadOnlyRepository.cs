namespace LivroDeReceitas.Core.Domain.Interfaces.Repositories.Usuario
{
    public interface IUsuarioReadOnlyRepository
    {
        Task<bool> ExisteUsuarioComEmail(string email);
    }
}
