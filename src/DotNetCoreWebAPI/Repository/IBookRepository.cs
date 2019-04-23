using DotNetCoreWebAPI.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotNetCoreWebAPI.Repository
{
    public interface IBookRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> Get(long id);
        Task Add(TEntity entity);
        Task Update(Book book, TEntity entity);
        Task Delete(Book book);
    }
}
