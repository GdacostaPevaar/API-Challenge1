using System.Linq.Expressions;

namespace Challenge1.Services
{
    public interface IGenericRepository<TEntity> 
    {
        Task<IEnumerable<TEntity>> GetAll();

        Task<TEntity> GetById(int id);

        Task<TEntity> Insert(TEntity entity);

        Task<TEntity> Update(TEntity entity);

        Task Delete(int id);


        Task<TEntity> FindByCondition(Expression<Func<TEntity, bool>> expression);


    }
}
