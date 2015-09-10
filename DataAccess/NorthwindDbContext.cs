using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using DataModel.Northwind;

namespace DataAccess
{
    public interface INorthwindDbContext : IContext
    {
        IDbSet<Categories> Categories { get; }
        IDbSet<Products> Products { get; }
        IDbSet<Customers> Customers { get; }
        IDbSet<Orders> Orders { get; }
    }

    public class NorthwindDbContext : NorthwindBaseContext<NorthwindDbContext>, INorthwindDbContext
    {
        //entity
        public IDbSet<Categories> Categories { get; set; }
        public IDbSet<Products> Products { get; set; }
        public IDbSet<Customers> Customers { get; set; }
        public IDbSet<Orders> Orders { get; set; }
        public IDbSet<Order_Details> Order_Details { get; set; }

        public void ExecuteSqlCommand(string sql)
        {
            this.Database.ExecuteSqlCommand(sql);
        }

        public void ExecuteSqlCommand(string sql, object[] parameters)
        {
            this.Database.ExecuteSqlCommand(sql, parameters);
        }
        
        public int SaveModifications()
        {
            return this.SaveModifications();
        }

        public void SetModified(object entity)
        {
            Entry(entity).State = System.Data.EntityState.Modified;
        }

        public void SetAdd(object entity)
        {
            Entry(entity).State = System.Data.EntityState.Added;
        }
    }
}
