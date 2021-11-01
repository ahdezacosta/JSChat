using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace JSChatModel
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        #region Attributes
        //DataBase Context
        public JSChatDBEntities _db = null;
        protected DbSet<T> _table = null;
        #endregion

        #region Constructor
       
        protected Repository()
        {
            _db = new JSChatDBEntities();
            _table = this._db.Set<T>();
            _db.Configuration.ProxyCreationEnabled = false;
        }
       
        protected Repository(JSChatDBEntities db)
        {
            _db = db;
            _table = this._db.Set<T>();
        }
        #endregion

        #region Methods
       
        public virtual JSChatDBEntities GetContext()
        {
            return this._db;
        }

        
        public virtual IQueryable<T> GetAll()
        {
            return _table.AsQueryable<T>();
        }

         
        public virtual IQueryable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return _table.Where(predicate).AsQueryable<T>();
        }

       
        public virtual T Find(int id)
        {
            return _table.Find(id);
        }

        
        public virtual T Find(string id)
        {
            return _table.Find(id);
        }

        
        public virtual T Find(Expression<Func<T, bool>> predicate)
        {
            return _table.FirstOrDefault(predicate);
        }

        
        public virtual T Add(T obj)
        {
            T addedRecord = null;
            addedRecord = _table.Add(obj);
            _db.SaveChanges();

            return addedRecord;
        }
 
        public virtual T AddInTransaction(T obj)
        {
            T addedRecord = null;
            addedRecord = _table.Add(obj);
            return addedRecord;
        }

       
        public virtual int Edit(T obj)
        {
            _table.Attach(obj);
            _db.Entry(obj).State = EntityState.Modified;
            var affectedRows = _db.SaveChanges();

            return affectedRows;
        }

        
        public virtual void EditInTransaction(T obj)
        {
            _table.Attach(obj);
            _db.Entry(obj).State = EntityState.Modified;
        }

       
        public virtual int Delete(T obj)
        {
            int affectedRows = 0;
            _table.Remove(obj);
            affectedRows = _db.SaveChanges();

            return affectedRows;
        }

        
        public virtual int Delete(Expression<Func<T, bool>> predicate)
        {
            int affectedRows = 0;
            var objects = _table.Where(predicate).AsEnumerable();
            foreach (var obj in objects)
                _table.Remove(obj);
            affectedRows = _db.SaveChanges();

            return affectedRows;
        }

       
        public virtual void DeleteInTransaction(T obj)
        {
            _table.Remove(obj);
        }

       
        public virtual void DeleteInTransaction(Expression<Func<T, bool>> predicate)
        {
            var objects = _table.Where(predicate).AsEnumerable();
            foreach (var obj in objects)
                _table.Remove(obj);
        }

        
        public virtual int SaveAllChanges()
        {
            int affectedRows = 0;
            affectedRows = _db.SaveChanges();
            return affectedRows;
        }

       
        public void Dispose()
        {
            if (_db != null)
                _db.Dispose();
        }
        #endregion
    }
}
