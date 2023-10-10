using LivroDeReceitas.Core.Domain.Interfaces.Repositories;
using LivroDeRecitas.Adapters.MYSQLServer.Context;

namespace LivroDeRecitas.Adapters.MYSQLServer.Repositories
{
    public class RepositoryBase: IRepositoryBase
    {
        private readonly LivroDeReceitasContext _livroDeReceitasContext;

        public RepositoryBase(LivroDeReceitasContext livroDeReceitasContext)
        {
            _livroDeReceitasContext = livroDeReceitasContext;
        }

        public async Task SaveAsync<T>(T obj)
        {
            try
            {
                if (obj is null) 
                    throw new ArgumentException("Object is null");

                await _livroDeReceitasContext.AddAsync(obj);
            }catch(Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
