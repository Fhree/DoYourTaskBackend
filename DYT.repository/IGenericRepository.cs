using System.Linq.Expressions;

namespace DYT.repository
{
    public interface IGenericRepository<T> where T : class
    {
        T Get(object id, params Expression<Func<T, object>>[] include);
        IEnumerable<T> GetAll(params Expression<Func<T, object>>[] relatedEntitys);
        void Add(T entity);
        void Update(T entity);
        void Delete(object id);
        void Save();
    }
}
