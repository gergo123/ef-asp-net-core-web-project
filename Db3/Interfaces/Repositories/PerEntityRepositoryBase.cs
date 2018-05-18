using Db3.Utils;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;

namespace Db3.Interfaces.Repositories
{
    public abstract class Repository<Entity> : IEntityRepository<Entity> where Entity : class
    {
        private DbContext _context;
        private DbSet<Entity> _dbSet;
        public Repository(DbContext context)
        {
            this._context = context;
            this._dbSet = context.Set<Entity>();
        }

        public virtual IQueryable<Entity> GetAll()
        {
            return _dbSet;
        }

        public IQueryable<Entity> Find(Expression<Func<Entity, bool>> query)
        {
            return _dbSet.Where(query);
        }

        public virtual Entity GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public virtual void Add(Entity item)
        {
            _dbSet.Add(item);
        }

        public virtual void Delete(Entity item)
        {
            _dbSet.Attach(item);
            _dbSet.Remove(item);
        }

        public virtual void Update(Entity item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        public void SaveChanges()
        {
            try
            {
                var errors = _context.GetValidationErrors();
                if (errors.Count() > 0 && errors.Any(x => !x.IsValid))
                {
                    throw new DbValidationException(errors);
                }
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }

        }

        public void Dispose()
        {
            this._context.Dispose();
        }
    }
}