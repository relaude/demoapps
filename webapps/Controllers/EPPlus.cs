using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OfficeOpenXml;
using OfficeOpenXml.Table;
using System.Data;
using System.Collections;
using System.IO;
using System.Reflection;

namespace webepplus.Controllers
{
    public class EPPlus
    {
        ExcelPackage package = new ExcelPackage();

        public List<T> Read<T>(string filePath, int fromRow = 2) where T : class
        {
            List<T> retList = new List<T>();
            int fromColumn = 1;

            using (var stream = File.OpenRead(filePath))
            {
                package.Load(stream);
            }
            var ws = package.Workbook.Worksheets.First();
            int toColumn = typeof(T).GetProperties().Count();

            for (var rowNum = fromRow; rowNum <= ws.Dimension.End.Row; rowNum++)
            {
                T objT = Activator.CreateInstance<T>();
                Type myType = typeof(T);
                PropertyInfo[] myProp = myType.GetProperties();

                var wsRow = ws.Cells[rowNum, fromColumn, rowNum, toColumn];

                for (int i = 0; i < myProp.Count() - 1; i++)
                {
                    try
                    {
                        if (myProp[i].PropertyType == typeof(string))
                            myProp[i].SetValue(objT, wsRow[rowNum, fromColumn + i].Text, null);

                        if (myProp[i].PropertyType == typeof(int))
                            myProp[i].SetValue(objT, int.Parse(wsRow[rowNum, fromColumn + i].Text), null);

                        if (myProp[i].PropertyType == typeof(bool))
                            myProp[i].SetValue(objT, bool.Parse(wsRow[rowNum, fromColumn + i].Text), null);

                        if (myProp[i].PropertyType == typeof(DateTime))
                            myProp[i].SetValue(objT, DateTime.Parse(wsRow[rowNum, fromColumn + i].Text), null);

                        if (myProp[i].PropertyType == typeof(double))
                            myProp[i].SetValue(objT, double.Parse(wsRow[rowNum, fromColumn + i].Text), null);
                    }
                    catch (Exception e)
                    {
                        string composeMsg = "Row: [" + rowNum.ToString() + "],  Column: [" + (fromColumn + i).ToString()
                            + "],  Value: [" + wsRow[rowNum, fromColumn + i].Text
                            + "],  Message: [" + e.Message + "]";
                        myProp[myProp.Count() - 1].SetValue(objT, composeMsg, null);
                    }
                }

                retList.Add(objT);
            }

            return retList;
        }
        
        public byte[] Export<T>(ICollection<T> Collection, string[] ColumnName, string CellRange)
        {
            package.Workbook.Worksheets.Add("Worksheet");
            ExcelWorksheet ws = package.Workbook.Worksheets[1];

            int Col = 0;
            //Column Name
            foreach (var item in ColumnName)
            {
                Col++;
                ws.Cells[1, Col].Value = item;
                ws.Cells[1, Col].Style.Font.Bold = true;
            }

            ws.Cells["A2"].LoadFromCollection(Collection, false, TableStyles.None);
            ws.Cells[CellRange].AutoFitColumns();//cella range sample "A1:P100"
            var memoryStream = package.GetAsByteArray();
            return memoryStream;
        }

        public byte[] Export<T>(ICollection<T> Collection, string CellRange)
        {
            package.Workbook.Worksheets.Add("Worksheet");
            ExcelWorksheet ws = package.Workbook.Worksheets[1];
            ws.Cells["A1"].LoadFromCollection(Collection, true, TableStyles.None);
            ws.Cells[CellRange].AutoFitColumns();//cella range sample "A1:P100"
            var memoryStream = package.GetAsByteArray();
            return memoryStream;
        }

        public byte[] Export<T>(ICollection<T> Collection)
        {
            package.Workbook.Worksheets.Add("Worksheet");
            ExcelWorksheet ws = package.Workbook.Worksheets[1];
            ws.Cells["A1"].LoadFromCollection(Collection, true, TableStyles.None);
            var memoryStream = package.GetAsByteArray();
            return memoryStream;
        }

        public byte[] Export<T>(ICollection<T> Collection, string[] HeaderText)
        {
            package.Workbook.Worksheets.Add("Worksheet");
            ExcelWorksheet ws = package.Workbook.Worksheets[1];
            int ctr = 0;

            foreach (var hdr in HeaderText)
            {
                ctr++;
                ws.Cells[1, ctr].Value = hdr;
            }

            ws.Cells["A2"].LoadFromCollection(Collection, false, TableStyles.None);
            var memoryStream = package.GetAsByteArray();
            return memoryStream;
        }

        public byte[] Export(DataTable DataTable)
        {
            package.Workbook.Worksheets.Add("Worksheet");
            ExcelWorksheet ws = package.Workbook.Worksheets[1];
            ws.Cells["A1"].LoadFromDataTable(DataTable, true, TableStyles.None);
            var memoryStream = package.GetAsByteArray();
            return memoryStream;
        }

        public void Create<T>(ICollection<T> Collection, string FileNameWithPath)
        {
            //Delete existing file with same file name.
            if (File.Exists(FileNameWithPath))
                File.Delete(FileNameWithPath);

            var newFile = new FileInfo(FileNameWithPath);

            package.File = newFile;
            package.Workbook.Worksheets.Add("Worksheet");
            ExcelWorksheet ws = package.Workbook.Worksheets[1];
            ws.Cells["A1"].LoadFromCollection(Collection, true, TableStyles.None);
            package.Save();
        }

        public void Create(DataTable DataTable, string FileNameWithPath)
        {
            //Delete existing file with same file name.
            if (File.Exists(FileNameWithPath))
                File.Delete(FileNameWithPath);

            var newFile = new FileInfo(FileNameWithPath);

            package.File = newFile;
            package.Workbook.Worksheets.Add("Worksheet");
            ExcelWorksheet ws = package.Workbook.Worksheets[1];
            ws.Cells["A1"].LoadFromDataTable(DataTable, true, TableStyles.None);
            package.Save();
        }
    }
}