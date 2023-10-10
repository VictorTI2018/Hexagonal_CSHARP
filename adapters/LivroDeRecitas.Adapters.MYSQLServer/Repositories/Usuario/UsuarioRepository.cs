using LivroDeReceitas.Core.Domain.Entities.Usuario;
using LivroDeReceitas.Core.Domain.Interfaces.Repositories.Usuario;
using LivroDeRecitas.Adapters.MYSQLServer.Context;
using Microsoft.EntityFrameworkCore;

namespace LivroDeRecitas.Adapters.MYSQLServer.Repositories.Usuario
{
    public class UsuarioRepository : RepositoryBase, IUsuarioWriteOnyRepository, IUsuarioReadOnlyRepository
    {
        private readonly LivroDeReceitasContext _context;

        public UsuarioRepository(LivroDeReceitasContext livroDeReceitasContext) : base (livroDeReceitasContext)
        {
            _context = livroDeReceitasContext;
        }

        public async Task<bool> ExisteUsuarioComEmail(string email)
        {
            return await _context.Usuarios.AnyAsync(x => x.Email.Equals(email));
        }

    }
}
