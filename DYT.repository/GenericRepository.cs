using DYT.infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DYT.repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DoYourTaskDBContext _dbContext;

        public GenericRepository(DoYourTaskDBContext dBContext)
        {
            _dbContext = dBContext ?? throw new ArgumentNullException(nameof(dBContext)); ;
        }

        public T Get(object id, params Expression<Func<T, object>>[] relatedEntitys)
        {
            if (id == null) throw new ArgumentNullException("id");
            
            IQueryable<T> query = _dbContext.Set<T>();
            AddIncludesToQuery(query, relatedEntitys);

            return query.ToList().Where(entity => GetPrimaryKeyValue(entity).Equals(id)).FirstOrDefault();
        }

        public IEnumerable<T> GetAll(params Expression<Func<T, object>>[] relatedEntitys)
        {
            var query = _dbContext.Set<T>();
            AddIncludesToQuery(query, relatedEntitys);
         
            return query.ToList();
        }

        public void Add(T entity)
        {
            if(entity == null) throw new ArgumentNullException("entity");

            _dbContext.Set<T>().Add(entity);
            this.Save();
        }
        public void Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");

            _dbContext.Set<T>().Update(entity);
            this.Save();
        }

        public void Delete(object id)
        {
            if (id == null) throw new ArgumentNullException("id");
            
            T entityToDelete = this.Get(id);
            if (entityToDelete != null)
            {
                _dbContext.Set<T>().Remove(entityToDelete);
                this.Save();
            }
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        private void AddIncludesToQuery(IQueryable<T> query,params Expression<Func<T, object>>[] includes) 
        {
            if (includes.Any())
            {
                foreach (var item in includes)
                {
                    query.Include(item);
                }
            }
        }

        private object GetPrimaryKeyValue(T entity)
        {
            var entityType = _dbContext.Model.FindEntityType(typeof(T));
            var primaryKey = entityType.FindPrimaryKey();
            return entity.GetType().GetProperty(primaryKey.Properties.FirstOrDefault().Name).GetValue(entity);
        }
    }
}
