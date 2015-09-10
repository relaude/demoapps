using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;
using DataModel.Northwind;
using System.Data.Entity;
using System.Data.SqlClient;

namespace Repository.Northwind
{
    public class CustomerRepository : ICustomers
    {
        private readonly INorthwindDbContext _context;

        public CustomerRepository(IUnitOfWork uow)
        {
            _context = uow.Context as INorthwindDbContext;
        }

        public object CustomerOrders()
        {
            var list = (_context.Customers
                            .Select(customer => new
                            {
                                id = customer.CustomerID,
                                firstName = customer.CompanyName,
                                lastName = customer.ContactName,
                                address = customer.Address,
                                city = customer.City,

                                orders = customer.Orders.Select(order => order.Order_Details
                                        .Select(od => new { 
                                                            product = od.Products.ProductName,
                                                            price = od.UnitPrice,
                                                            quantity = od.Quantity,
                                                            orderTotal = od.UnitPrice * od.Quantity
                                                        }
                                        )
                                    )
                                
                            })
                )
                .Take(12)
                .ToList();

            return list;
        }
        
        public IQueryable<Customers> All
        {
            get { return _context.Customers; }
        }

        public IQueryable<Customers> AllIncluding(params System.Linq.Expressions.Expression<Func<Customers, object>>[] includeProperties)
        {
            IQueryable<Customers> query = _context.Customers;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Customers Find(int id)
        {
            throw new NotImplementedException();
        }

        public Customers Find(string id)
        {
            return _context.Customers.Find(id);
        }

        public void InsertOrUpdate(Customers entity)
        {
            if (entity.CustomerID == default(string))
            {
                _context.SetAdd(entity);
            }
            else
            {
                _context.SetModified(entity);
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            var entity = _context.Customers.Find(id);
            _context.Customers.Remove(entity);
        }

        public void Save()
        {
            _context.SaveModifications();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
