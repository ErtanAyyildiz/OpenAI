using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OpenAI.Business.Abstracts
{
    public interface IGenericService<T>
    {
        void Add(T entity);
        void Remove(T entity);
        void Update(T entity);
        T GetByID(int id);
        List<T> GetListByFilter(Expression<Func<T, bool>> filter);
        IEnumerable<T> GetList();
    }
}
