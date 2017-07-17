using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lesson09
{

    class Program
    {
        static void Main(string[] args)
        {
            DataSet1 ds = new DataSet1();
            DataSet1TableAdapters.OrdersTableAdapter orderAdapter = new DataSet1TableAdapters.OrdersTableAdapter();

            orderAdapter.FillBy(ds.Orders, 4);
           //  DataSet1.OrdersDataTable table = orderAdapter.GetDataBy(4);

            Console.WriteLine("CusID - EmpID");
            Console.WriteLine("==============");
            foreach (var item in ds.Orders)
            {
                Console.WriteLine(item.CustomerID + " - " + item.EmployeeID);
            }

            Console.ReadLine();
        }
    }
}

