namespace LivroDeReceitas.Core.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase
    {
        Task SaveAsync<T>(T obj);
    }
}
