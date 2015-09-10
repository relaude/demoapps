using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;
using DataModel.Northwind;
using System.Data.Entity;

namespace Repository.Northwind
{
    public class CategoryRepository : ICategories
    {
        private readonly INorthwindDbContext _context;

        public CategoryRepository(IUnitOfWork uow)
        {
            _context = uow.Context as INorthwindDbContext;
        }
        
        public IQueryable<Categories> All
        {
            get { return _context.Categories; }
        }

        public IQueryable<Categories> AllIncluding(params System.Linq.Expressions.Expression<Func<Categories, object>>[] includeProperties)
        {
            IQueryable<Categories> query = _context.Categories;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Categories Find(int id)
        {
            return _context.Categories.Find(id);
        }

        public void InsertOrUpdate(Categories entity)
        {
            if (entity.CategoryID == default(int))
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
            var entity = _context.Categories.Find(id);
            _context.Categories.Remove(entity);
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
