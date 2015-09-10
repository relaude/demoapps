using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;
using DataModel.Northwind;
using System.Data.SqlClient;

namespace Repository.Northwind
{
    public class ProductsRepository : IProducts
    {
        private readonly INorthwindDbContext _context;

        public ProductsRepository(IUnitOfWork uow)
        {
            _context = uow.Context as INorthwindDbContext;
        }

        public void Insert(Products entity)
        {
            List<object> parameters = new List<object>();

            SqlParameter ProductName = new SqlParameter("@ProductName", entity.ProductName);
            parameters.Add(ProductName);

            SqlParameter QuantityPerUnit = new SqlParameter("@QuantityPerUnit", entity.QuantityPerUnit);
            parameters.Add(QuantityPerUnit);

            SqlParameter UnitPrice = new SqlParameter("@UnitPrice", entity.UnitPrice);
            parameters.Add(UnitPrice);

            SqlParameter UnitsInStock = new SqlParameter("@UnitsInStock", entity.UnitsInStock);
            parameters.Add(UnitsInStock);
            
            string sql = "INSERT INTO [Northwind].[dbo].[Products] ([ProductName],[QuantityPerUnit],[UnitPrice],[UnitsInStock])"
                +" VALUES(@ProductName,@QuantityPerUnit,@UnitPrice,@UnitsInStock)";
            
            _context.ExecuteSqlCommand(sql, parameters.ToArray());
        }

        public IQueryable<Products> All
        {
            get { return _context.Products; }
        }

        public IQueryable<DataModel.Northwind.Products> AllIncluding(params System.Linq.Expressions.Expression<Func<DataModel.Northwind.Products, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public DataModel.Northwind.Products Find(int id)
        {
            throw new NotImplementedException();
        }

        public void InsertOrUpdate(DataModel.Northwind.Products entity)
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
