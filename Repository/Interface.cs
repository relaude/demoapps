using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using DataModel.Northwind;

namespace Repository
{
    //Northwind
    public interface ICategories : Interface<Categories> { }
    public interface IProducts : Interface<Products> { }
    public interface ICustomers : Interface<Customers> { }
    public interface IOrders : Interface<Orders> { }
    public interface IOrder_Details : Interface<Order_Details> { }
    
    public interface Interface<T> : IDisposable
    {
        IQueryable<T> All { get; }
        IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties);
        T Find(int id);
        void InsertOrUpdate(T entity);
        void Delete(int id);
        void Save();
    }
}
