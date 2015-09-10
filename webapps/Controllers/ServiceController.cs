using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using DataModel.Northwind;
using Newtonsoft.Json;

namespace webepplus.Controllers
{
    public class ServiceController : ApiController
    {
        ServicePovider.Northwind _service = new ServicePovider.Northwind();

        public IEnumerable<Products> Get()
        {
            return _service.ProductsRepo.All.ToArray();
        }


    }
}
