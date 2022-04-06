using NUCA.Common;
using NUCA.Common.DDD;
using System.Linq.Expressions;


namespace NUCA.Boqs.Application.Interfaces.Persistence
{
    public interface IRepository<T> where T : AggregateRoot
    {

        IEnumerable<T> All();
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        T Add(T entity);
        T Update(T entity);
        T Get(long id);
        void Delete(long id);
        public Task SaveChangesAsync();

    }
}
