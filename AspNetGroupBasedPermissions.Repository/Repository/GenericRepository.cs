using System;
using System.Linq;
using System.Linq.Expressions;
using HospitalRepository.DBContext;
using HospitalRepository.Interface;

namespace HospitalRepository.Repository
{
    public abstract class GenericRepository<T, TKey> : IGenericRepository<T, TKey> where T : class
    {
        private readonly ApplicationDbContext _context;

        protected GenericRepository(ApplicationDbContext context)
        {
            this._context = context;
        }


        public virtual T Create(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            if (_context.Set<T>().Add(entity) != null)
            {
                SaveChanges();
                return entity;
            }

            return null;
        }


        public virtual T FindById(TKey id)
        {
            return _context.Set<T>().Find(id);
        }


        public void Update(TKey key, T entity)
        {
            var savedrecord = _context.Set<T>().Find(key);
            _context.Entry(savedrecord).CurrentValues.SetValues(entity);
            SaveChanges();

        }


        public virtual bool Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
                return false;
            }
            _context.Set<T>().Remove(entity);
            SaveChanges();
            return true;
        }


        public virtual bool Delete(TKey id)
        {
            var dbSet = _context.Set<T>();
            var result = dbSet.Find(id);

            if (result != null)
            {
                dbSet.Remove(result);
                SaveChanges();
                return true;
            }
            return false;
        }
        public IQueryable<T> GetAll()
        {
            return _context.Set<T>().AsQueryable();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public IQueryable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {

            IQueryable<T> query = _context.Set<T>().Where(predicate);
            return query;
        }

        public virtual void UpdateFields(T entity, params Expression<Func<T, object>>[] updatedProperties)
        {
            //dbEntityEntry.State = EntityState.Modified; --- I cannot do this.

            //Ensure only modified fields are updated.
            var dbEntityEntry = _context.Entry(entity);
            if (updatedProperties.Any())
            {
                //update explicitly mentioned properties
                foreach (var property in updatedProperties)
                {
                    dbEntityEntry.Property(property).IsModified = true;
                }
            }
            else
            {
                //no items mentioned, so find out the updated entries
                foreach (var property in dbEntityEntry.OriginalValues.PropertyNames)
                {
                    var original = dbEntityEntry.OriginalValues.GetValue<object>(property);
                    var current = dbEntityEntry.CurrentValues.GetValue<object>(property);
                    if (original != null && !original.Equals(current))
                        dbEntityEntry.Property(property).IsModified = true;
                    SaveChanges();
                }
            }
        }

        public void Dispose()
        {
            // _context.SaveChanges();
            _context.Dispose();
        }
    }
}