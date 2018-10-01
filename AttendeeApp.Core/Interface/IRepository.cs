using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AttendeeApp.Core.Interface
{
    public interface IRepository<TEntity> where TEntity : class
    {
        ICollection<TEntity> GetAll();
        ICollection<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        TEntity Get(Guid id);

        void Add(TEntity entity);
        void AddRange(ICollection<TEntity> entities);
        void Update(TEntity entity);

        void Remove(TEntity entity);
        void RemoveRange(ICollection<TEntity> entities);
    }
}