using System.Linq.Expressions;
using NUCA.Projects.Application.Interfaces.Persistence;
using NUCA.Common.DDD;

namespace NUCA.Projects.Data.Shared
{
    public class Repository<T> : IRepository<T>  where T : AggregateRoot
    {
        protected readonly DatabaseContext database;

        public Repository(DatabaseContext database)
        {
            this.database = database;
        }

        public virtual T Add(T entity)
        {
            T item = database.Set<T>().Add(entity).Entity;
            database.SaveChanges();
            return item;
        }

        public virtual IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return database.Set<T>().AsQueryable().Where(predicate).ToList();
        }

        public virtual T Get(long id)
        {
            return database.Set<T>().Find(id);
        }

        public virtual IEnumerable<T> All()
        {
            return database.Set<T>().ToList();
        }

        public virtual T Update(T entity)
        {
            T item = database.Set<T>().Update(entity).Entity;
            database.SaveChanges();
            return item;
        }

        public virtual void Delete(long id)
        {
            var entity =  database.Set<T>().Find(id);
            if (entity == null) return;
            database.Set<T>().Remove(entity);
            database.SaveChanges();
        }

        public virtual Task SaveChangesAsync()
        {
           return database.SaveChangesAsync();
        }

        public virtual void SaveChanges()
        {
            database.SaveChanges();
        }

    }
}
