using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess
{
    public interface IContext : IDisposable
    {
        //custom
        void ExecuteSqlCommand(string sql);
        void ExecuteSqlCommand(string sql, object[] parameters);
        
        //default
        int SaveModifications();
        void SetModified(object entity);
        void SetAdd(object entity);
    }
}
