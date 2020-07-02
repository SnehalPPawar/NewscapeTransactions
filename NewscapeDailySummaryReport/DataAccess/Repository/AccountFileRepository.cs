using NewscapeDailySummaryReport.DataAccess.Interfaces;
using NewscapeDailySummaryReport.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace NewscapeDailySummaryReport.DataAccess.Repository
{
    public class AccountFileRepository : IAccountRepository
    {
        public AccountFileRepository()
        {

        }
        public List<Account> GetAllRecords()
        {
            string FilePath = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName) + @"\TransactionSummary.csv";
            return ConvertDataTableToEntity<Account>(ConvertCsvToDatatable(FilePath));
        }

        private DataTable ConvertCsvToDatatable(string FilePath)
        {
            string pathOnly = Path.GetDirectoryName(FilePath);
            string fileName = Path.GetFileName(FilePath);

            string sql = @"SELECT * FROM [" + fileName + "]";

            using (OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathOnly + ";Extended Properties=\"Text;HDR=yes\""))
            using (OleDbCommand command = new OleDbCommand(sql, connection))
            using (OleDbDataAdapter adapter = new OleDbDataAdapter(command))
            {
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
        }
        private List<T> ConvertDataTableToEntity<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetEntity<T>(row);
                data.Add(item);
            }
            return data;
        }
        private T GetEntity<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }
    }
}
