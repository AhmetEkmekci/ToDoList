using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.DataAccessLayer
{
    public interface IRepository<T> where T : Model.BaseTable
    {

        IQueryable<T> GetAll();
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void AddOrUpdate(T entity);
        void Delete(T entity);
        void Delete(int id);
        void Save();
    }
}
