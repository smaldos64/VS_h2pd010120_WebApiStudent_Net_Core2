using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WebApiStudent_Net_Core2.Interfaces
{
    public interface IDataRepository<T>
    {
        IEnumerable<T> GetAll();
        T Get(long id);
        void Add(T entity);
        void Update(T dbEntity, T entity);
        void Delete(T entity);
    }
}
