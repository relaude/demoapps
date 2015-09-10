using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;
using Repository.Northwind;

namespace ServicePovider
{
    public class Northwind
    {
        private readonly UnitOfWork<NorthwindDbContext> _uow;
        private readonly CategoryRepository _category;
        private readonly OrdersRepository _orders;
        private readonly CustomerRepository _customers;
        private readonly ProductsRepository _products;

        public Northwind()
        {
            _uow = new UnitOfWork<NorthwindDbContext>();
            _category = new CategoryRepository(_uow);
            _orders = new OrdersRepository(_uow);
            _customers = new CustomerRepository(_uow);
            _products = new ProductsRepository(_uow);
        }

        public CategoryRepository CategoryRepo
        {
            get { return _category; }
        }

        public OrdersRepository OrdersRepo
        {
            get { return _orders; }
        }

        public CustomerRepository CustomerRepo
        {
            get { return _customers; }
        }

        public ProductsRepository ProductsRepo
        {
            get { return _products; }
        }
    }
}
