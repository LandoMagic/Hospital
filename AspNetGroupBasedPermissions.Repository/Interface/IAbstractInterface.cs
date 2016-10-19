using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AspNetGroupBasedPermissions.Repository.Interface
{
    public interface IGenericRepository<T, TKey> where T : class
    {


        IQueryable<T> GetAll();
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        T FindById(TKey id);
        T Create(T entity);
        bool Delete(T entity);
        bool Delete(TKey id);
        void Update(TKey key, T entity);
        void UpdateFields(T entity, params Expression<Func<T, object>>[] updatedProperties);
        int SaveChanges();
    }
}
