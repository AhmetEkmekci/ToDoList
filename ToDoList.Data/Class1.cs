using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Model;

namespace ToDoList.Data
{
    public class DataBaseContext : DbContext
    {
        public void AddOrUpdate<EntityType>(DbSet<EntityType> dbs, System.Linq.Expressions.Expression<System.Func<EntityType, object>> fnc, ref EntityType entity)
            where EntityType : class
        {
            System.Data.Entity.Migrations.DbSetMigrationsExtensions.AddOrUpdate(dbs, fnc, entity);

        }

        public DbSet<Entry> Entries { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");
            modelBuilder.Entity<Entry>().ToTable("Entry", "dbo").HasKey(x=>x.Id);
        }
    }
}
