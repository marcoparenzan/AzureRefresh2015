using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text; 
using System.Threading.Tasks;

namespace Import.Customers
{
    static class Customers
    {
        public static void Import()
        {
            var dbContext = new CustomerDbContext();
            var folderName = "Customers";
            if (!Directory.Exists(folderName)) Directory.CreateDirectory(folderName);
            var i = 0;
            foreach (var item in dbContext.Customer.Include("CustomerAddress").Include("CustomerAddress.Address").Include("SalesOrderHeader").ToList())
            {
                if (item.SalesOrderHeader.Count == 0) continue;
                File.WriteAllText(Path.Combine(folderName, item.CustomerID.ToString() + ".json"), JsonConvert.SerializeObject(item));
                Console.WriteLine(++i);
            }
        }
    }
}
