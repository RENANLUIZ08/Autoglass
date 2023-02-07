using System;
using System.Linq.Expressions;

namespace Autoglass.Domain.Repository.Interfaces
{
    public interface IRepositoryBase<Entity> where Entity : class
    {
        Entity GetFirst(Expression<Func<Entity, bool>> predicate);
        Entity InsertDb(Entity entity);
        Entity UpdateDb(Entity entity);
        bool Commit();
    }
}
