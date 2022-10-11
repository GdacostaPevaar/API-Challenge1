using AutoMapper;
using Challenge1.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Challenge1.Services
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {

        private readonly ChallengeDBContext _context;

  

        public GenericRepository(ChallengeDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));



        }
       
        public async Task Delete(int id)
        {
            var entity = await GetById(id);

            if (entity == null)
                throw new Exception("The entity is null");

            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _context.Set<TEntity>() .ToListAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }


        public async Task<TEntity> FindByCondition(Expression<Func<TEntity, bool>> expression)
        {
            return await _context.Set<TEntity>().Where(expression).FirstOrDefaultAsync();
        }

        public virtual async Task<TEntity> Insert(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Update(TEntity entity)
        {
       

            _context.Entry(entity).State = EntityState.Modified;

            await _context.SaveChangesAsync();

      
            return entity;
        }

  
    }
}
