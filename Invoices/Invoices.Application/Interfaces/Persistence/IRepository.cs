using NUCA.Invoices.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NUCA.Invoices.Application.Interfaces.Persistence
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
