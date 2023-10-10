using LivroDeReceitas.Core.Domain.Interfaces.Repositories;
using LivroDeRecitas.Adapters.MYSQLServer.Context;

namespace LivroDeRecitas.Adapters.MYSQLServer.Repositories
{
    public sealed class UnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly LivroDeReceitasContext _context;

        private bool _disposed;

        public UnitOfWork(LivroDeReceitasContext livroDeReceitasContext)
        {
            _context = livroDeReceitasContext;
        }

        public async Task Commit ()
        {
           await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed && disposing) _context.Dispose();

            _disposed = true;
        }
    }
}
