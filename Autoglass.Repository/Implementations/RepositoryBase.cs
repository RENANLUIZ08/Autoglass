using Autoglass.Domain.Repository.Interfaces;
using Autoglass.Service.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Autoglass.Repository.Implementations
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly DbContext _context;
        protected DbSet<TEntity> DbSet;

        public RepositoryBase(DbContext context)
        {
            _context = context;
            DbSet = _context.Set<TEntity>();
        }

        public TEntity InsertDb(TEntity entity)
        => DbSet.Add(entity).Entity;        

        public TEntity UpdateDb(TEntity entity)
        => DbSet.Update(entity).Entity;

        public bool Commit()
        => _context.SaveChanges() > 0;

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> where = null)
        => where == null? DbSet.ToList() : DbSet.Where(where).ToList();        
    }
}
