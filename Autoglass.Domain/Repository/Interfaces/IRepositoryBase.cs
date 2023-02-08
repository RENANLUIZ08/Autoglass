using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Autoglass.Service.Repository.Interfaces
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        List<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null);
        TEntity InsertDb(TEntity entity);
        TEntity UpdateDb(TEntity entity);
        bool Commit();
    }
}
