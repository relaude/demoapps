using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataModel.Northwind;
using DataAccess;

namespace Repository.Northwind
{
    public class Order_DetailsRepository : IOrder_Details
    {
        private readonly INorthwindDbContext _context;

        public Order_DetailsRepository(IUnitOfWork uow)
        {
            _context = uow.Context as INorthwindDbContext;
        }

        public IQueryable<Order_Details> All
        {
            get { throw new NotImplementedException(); }
        }

        public IQueryable<DataModel.Northwind.Order_Details> AllIncluding(params System.Linq.Expressions.Expression<Func<DataModel.Northwind.Order_Details, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public DataModel.Northwind.Order_Details Find(int id)
        {
            throw new NotImplementedException();
        }

        public void InsertOrUpdate(DataModel.Northwind.Order_Details entity)
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
