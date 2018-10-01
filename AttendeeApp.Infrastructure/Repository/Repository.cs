using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using AttendeeApp.Core.Interface;

namespace AttendeeApp.Infrastructure.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Db;

        public Repository(DbContext db)
        {
            Db = db;
        }

        public ICollection<TEntity> GetAll()
        {
            return Db.Set<TEntity>().ToList();
        }

        public ICollection<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Db.Set<TEntity>().Where(predicate).ToList();
        }

        public TEntity Get(Guid id)
        {
            return Db.Set<TEntity>().Find(id);
        }

        public void Add(TEntity entity)
        {
            Db.Set<TEntity>().Add(entity);
        }

        public void AddRange(ICollection<TEntity> entities)
        {
            Db.Set<TEntity>().AddRange(entities);
        }

        public void Update(TEntity entity)
        {
            Db.Entry(entity).State = EntityState.Modified;
        }

        public void Remove(TEntity entity)
        {
            //Db.Set<TEntity>().Remove(entity);
            Db.Entry(entity).State = EntityState.Deleted;
        }

        public void RemoveRange(ICollection<TEntity> entities)
        {
            Db.Set<TEntity>().RemoveRange(entities);
        }
    }
}