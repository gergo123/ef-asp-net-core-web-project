using System;
using System.Linq;
using System.Linq.Expressions;

namespace Db3.Interfaces.Repositories
{
    public interface IEntityRepository<Entity> : IDisposable where Entity : class
    {
        IQueryable<Entity> GetAll();
        IQueryable<Entity> Find(Expression<Func<Entity, bool>> query);
        Entity GetById(int id);
        void Add(Entity item);
        void Delete(Entity item);
        void Update(Entity item);
        void SaveChanges();
    }
}