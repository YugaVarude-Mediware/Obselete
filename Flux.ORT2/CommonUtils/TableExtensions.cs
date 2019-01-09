using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Flux.ORT2.CommonUtils
{
    public class TableExtensions
    {

        /// <summary>
        /// This methods converts the SpecFlow tables into DataTable type
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public static DataTable ToDataTable(Table table)
        {
            var dataTable = new DataTable();

            foreach (var header in table.Header)
            {
                dataTable.Columns.Add(header, typeof(string));
            }

            foreach (var row in table.Rows)
            {
                var newRow = dataTable.NewRow();
                foreach (var header in table.Header)
                {
                    newRow[header] = row[header];
                }
                dataTable.Rows.Add(newRow);
            }
            return dataTable;
        }

        /// <summary>
        /// This methdod will create scenario context values from table
        /// </summary>
        /// <param name="table"></param>
        public static void InitializeScenarioContext(Table table)
        {
            foreach (var header in table.Header)
            {
                ScenarioContext.Current[header.ToString()] = string.Empty;
            }

            foreach (var row in table.Rows)
            {

                foreach (var header in table.Header)
                {
                    ScenarioContext.Current[header.ToString()] = row[header];
                }

            }
        }
    }
}
