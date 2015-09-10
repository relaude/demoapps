using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataModel.Northwind;
using DataAccess;

namespace Repository.Northwind
{
    public class OrdersRepository : IOrders
    {
        private readonly INorthwindDbContext _context;

        public OrdersRepository(IUnitOfWork uow)
        {
            _context = uow.Context as INorthwindDbContext;
        }

        public object SummaryOfOrders()
        {
            var list = (_context.Orders
                            .Select(order => new
                            {
                                id = order.CustomerID,
                                firstName = order.Customers.CompanyName,
                                lastName = order.Customers.ContactName,
                                address = order.Customers.Address,
                                city = order.Customers.Country,
                                product = order.Order_Details.Select(p=>p.Products.ProductName),
                                price = order.Order_Details.Select(p=>p.UnitPrice),
                                quantity = order.Order_Details.Select(q=>q.Quantity),
                                orderTotal = order.Order_Details.Select(t=>t.UnitPrice * t.Quantity)
                            })
                        )
                       .Take(10)
                       .ToList();

            return list;
        }

        public IQueryable<Orders> All
        {
            get { throw new NotImplementedException(); }
        }

        public IQueryable<DataModel.Northwind.Orders> AllIncluding(params System.Linq.Expressions.Expression<Func<DataModel.Northwind.Orders, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public DataModel.Northwind.Orders Find(int id)
        {
            return _context.Orders.Find(id);
        }

        public void InsertOrUpdate(DataModel.Northwind.Orders entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
