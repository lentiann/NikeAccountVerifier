using Excel;
using System;
using System.Collections.Generic;
using System.Data;
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
        public static void PopulateInCollection(string fileName)
        {
            DataTable table = ExcelToDataTable(fileName);

            for (int row = 1; row <= table.Rows.Count; row++)
            {
                for (int col = 0; col < table.Columns.Count; col++)
                {
                    DataCollection dtTable = new DataCollection()
                    {
                        rowNumber = row,
                        colName = table.Columns[col].ColumnName,
                        colValue = table.Rows[row - 1][col].ToString()
                    };
                    dataCol.Add(dtTable);
                }
            }
        }
        /// <summary>
        /// Reading all the dates from ExcelSheet
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private static DataTable ExcelToDataTable(string fileName)
        {
            FileStream stream = File.Open(fileName, FileMode.Open, FileAccess.Read);

            IExcelDataReader excelDataReader = ExcelReaderFactory.CreateOpenXmlReader(stream);

            excelDataReader.IsFirstRowAsColumnNames = true;

            DataSet result = excelDataReader.AsDataSet();

            DataTableCollection table = result.Tables;

            DataTable resulTable = table["Sheet1"];

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

    }


    public class DataCollection
    {
        public int rowNumber { get; set; }
        public string colName { get; set; }
        public string colValue { get; set; }
         
    }
}
