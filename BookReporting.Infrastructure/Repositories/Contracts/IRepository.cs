using BookReporting.Domain.AggregateRoots;
using System.Threading.Tasks;

namespace BookReporting.Infrastructure.Repositories.Contracts
{
    public interface IRepository<TEntity> where TEntity : IAggregateRoot
    {
    }

    public interface ILibrarianRepository<TEntity> : IRepository<TEntity> where TEntity : IAggregateRoot
    {
        Task<TEntity> Get(string path);
    }

    public interface IStudentRepository<TEntity> : IRepository<TEntity> where TEntity : IAggregateRoot
    {
        Task<TEntity> Get(string path, string searchKey);
    }

    public interface IResearcherRepository<TEntity> : IRepository<TEntity> where TEntity : IAggregateRoot
    {
        Task<TEntity> Get(string path);
    }

    public interface IBusinessAnalystRepository<TEntity> : IRepository<TEntity> where TEntity : IAggregateRoot
    {
        Task<TEntity> Get(string path);
    }
}
