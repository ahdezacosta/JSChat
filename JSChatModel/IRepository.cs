using System;
using System.Linq;
using System.Linq.Expressions;

namespace JSChatModel
{
    public interface IRepository<T> where T : class
    {
        #region Methods
       
        IQueryable<T> GetAll();
        
        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate);

        
        T Find(int id);
         
        T Find(Expression<Func<T, bool>> predicate);
        
        T Add(T obj);
        
        int Edit(T obj);
        
        int Delete(T obj);
       
        int Delete(Expression<Func<T, bool>> predicate);

        #endregion
    }
}
