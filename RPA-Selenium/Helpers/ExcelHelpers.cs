using Excel;
using RPAFramework.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;

namespace RPAFramework.Helpers
{
    public class ExcelHelpers
    {
        private static List<DataCollection> dataCol = new List<DataCollection>();

        /// <summary>
        /// Storing all excel values into in memory collection
        /// </summary>
        /// <param name="fileName"></param>
        public static List<Register> PopulateInCollection(string fileName, string sheetName)
        {
            DataTable table = ExcelToDataTable(fileName, sheetName);
            List<Register> tempList = new List<Register>();
            for (int row = 0; row <= table.Rows.Count - 1; row++)
            {
                tempList.Add(new Register()
                {
                    Email = table.Rows[row]["email"].ToString(),
                    Password = table.Rows[row]["password"].ToString(),
                    FirstName = table.Rows[row]["firstname"].ToString(),
                    LastName = table.Rows[row]["firstname"].ToString(),
                    DateOfBirth = string.Format("{0:MM/dd/yyyy}", table.Rows[row]["dateOfBirth"]),
                    Country = table.Rows[row]["country"].ToString(),
                    Sex = table.Rows[row]["sex"].ToString()
                });
            }
            return tempList;
        }


        /// <summary>
        /// Reading all the dates from ExcelSheet
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private static DataTable ExcelToDataTable(string fileName, string sheetName)
        {
            FileStream stream = File.Open(fileName, FileMode.Open, FileAccess.Read);

            IExcelDataReader excelDataReader = ExcelReaderFactory.CreateOpenXmlReader(stream);

            excelDataReader.IsFirstRowAsColumnNames = true;

            DataSet result = excelDataReader.AsDataSet();

            DataTableCollection table = result.Tables;

            DataTable resulTable = table[sheetName];

            return resulTable;
        }

        public static string ReadData(int rowNumber, string columnName)
        {
            try
            {
                string data = (from colData in dataCol
                               where colData.colName == columnName && colData.rowNumber == rowNumber
                               select colData.colValue).SingleOrDefault();

                return data.ToString();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static List<string> ReadData(string columnName)
        {
            List<string> data = (from colData in dataCol
                                 where colData.colName == columnName
                                 select colData.colValue).ToList();
            return data;
        }

    }




    public class DataCollection
    {
        public int rowNumber { get; set; }
        public string colName { get; set; }
        public string colValue { get; set; }

    }
}
