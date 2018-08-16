using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Data;
using ToDoList.Model;

namespace ToDoList.DataAccessLayer
{
    public class EntryRepository: IRepository<Model.Entry>
    {
        DataBaseContext db;
        public EntryRepository()
        {
            db = new DataBaseContext();
        }

        public void Add(Entry entity)
        {
            db.Entries.Add(entity);
        }

        public void AddOrUpdate(Entry entity)
        {
            db.AddOrUpdate(db.Entries,x=>x.Id, ref entity);
        }

        public void Delete(Entry entity)
        {
            db.Entries.Remove(entity);
        }
        public void Delete(int id)
        {
            db.Entries.Remove(db.Entries.FirstOrDefault(x=>x.Id == id));
        }

        public IQueryable<Entry> FindBy(Expression<Func<Entry, bool>> predicate)
        {
            return db.Entries.Where(predicate);
        }

        public IQueryable<Entry> GetAll()
        {
            return db.Entries;
        }

        public void Save()
        {
            db.SaveChanges();
        }

    }
}
