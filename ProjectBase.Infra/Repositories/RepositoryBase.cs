using Microsoft.EntityFrameworkCore;
using ProjectBase.Domain.Base;
using ProjectBase.Domain.Interfaces;
using ProjectBase.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProjectBase.Infra.Repositories
{
    public abstract class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : EntityBase, new()
    {
        protected readonly MyDbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public RepositoryBase(MyDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }
        public async Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task<TEntity> GetById(Guid id)
        {
            return await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }
        public virtual async Task Add(TEntity entity)
        {
            _dbSet.Add(entity);
            await SaveChanges();
        }

        public virtual async Task Update(TEntity entity)
        {
            _dbSet.Update(entity);
            await SaveChanges();

        }
        public virtual async Task Remove(Guid id)
        {
            _dbSet.Remove(new TEntity { Id = id });
            await SaveChanges();
        }
        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
