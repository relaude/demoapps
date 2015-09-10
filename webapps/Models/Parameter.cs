using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webepplus.Models
{
    public class ReadExcel
    {
        public string filePath { get; set; }
        public int fromRow { get; set; }
        public int fromColumn { get; set; }
        public int toColumn { get; set; }
    }
}