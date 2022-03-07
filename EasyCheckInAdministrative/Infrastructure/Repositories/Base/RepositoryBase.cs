using Core.DataInterfaces.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Base
{
    public class RepositoryBase<T> : IRepository<T> where T : class
    {
        protected readonly ECADbContext _context;

        public RepositoryBase(ECADbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public void Create(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
           _context.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
        
        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<T> GetFirstByExpressionAsync(Expression<Func<T, bool>> expr)
        {
            return await _context.Set<T>().Where(expr).FirstOrDefaultAsync();
        }
    }
}
