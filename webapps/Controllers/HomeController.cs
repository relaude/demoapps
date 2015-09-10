using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using webepplus.Models;
using System.IO;

namespace webepplus.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ReadExcelFile(HttpPostedFileBase file)
        {
            var fileName = Path.GetFileName(file.FileName);
            var path = Path.Combine(Server.MapPath("~/tempfile"), fileName);
            file.SaveAs(path);
            
            EPPlus epplus = new EPPlus();
            List<ExampleData> sampleDataList = new List<ExampleData>();
            sampleDataList = epplus.Read<ExampleData>(path);

            System.IO.File.Delete(path);

            return Json(sampleDataList,JsonRequestBehavior.AllowGet);
        }
    }
}
