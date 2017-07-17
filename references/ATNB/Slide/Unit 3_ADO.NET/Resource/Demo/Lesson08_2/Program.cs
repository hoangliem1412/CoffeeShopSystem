using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Lesson08_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // instantiate the DataTable
            DataTable table = new DataTable("Persons");

            // Add columns
            DataColumn col = new DataColumn("ID", typeof(int));
            col.AllowDBNull = false;
            col.AutoIncrement = true;
            col.AutoIncrementSeed = 1;
            col.Unique = true;
            table.Columns.Add(col);


            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Birthday", typeof(DateTime));

            // Add rows
            DataRow newRow = table.NewRow();
            newRow["ID"] = 1; 
            newRow["Name"] = "Boo";
            newRow["Birthday"] = new DateTime(1990, 3, 4);
            table.Rows.Add(newRow);

            table.Rows.Add(2, "Bee", new DateTime(1989, 5, 3));

            foreach (DataRow row in table.Rows)
            {
                Console.WriteLine("ID={0}, Name={1}, Birthday={2}",
                    row["ID"], row["Name"], row["Birthday"]);
            }

            Console.ReadLine();
        }
    }
}
