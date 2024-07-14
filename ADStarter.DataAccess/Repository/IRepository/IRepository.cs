using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ADStarter.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        //T - Program
        T GetFirstOrDefault(Expression<Func<T, bool>> filter, string includeProperties = null);
        IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, string includeProperties = null);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAllWithIncludes(params Expression<Func<T, object>>[] includes);
        T Get(Expression<Func<T, bool>> filter);
        T GetFirstOrDefault(Expression<Func<T, bool>> filter); // Add this line
        void Add(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entity);
    }

}
