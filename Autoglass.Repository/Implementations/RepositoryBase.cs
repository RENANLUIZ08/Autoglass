using Autoglass.Domain.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Autoglass.Repository.Implementations
{
    public class RepositoryBase<Entity> : IRepositoryBase<Entity> where Entity : class
    {
        private readonly DbContext _context;
        protected DbSet<Entity> DbSet;

        public RepositoryBase(DbContext context)
        {
            _context = context;
            DbSet = _context.Set<Entity>();
        }

        public Entity InsertDb(Entity entity)
        => DbSet.Add(entity).Entity;

        

        public Entity UpdateDb(Entity entity)
        => DbSet.Update(entity).Entity;


        public bool Commit()
        => _context.SaveChanges() > 0;

        public Entity GetFirst(Expression<Func<Entity, bool>> where)
        => DbSet.Where(where).FirstOrDefault();
        
    }
}
