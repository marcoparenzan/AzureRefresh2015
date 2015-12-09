using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text; 
using System.Threading.Tasks;

namespace Import.Orders
{
    static class Orders
    {
        public static void Import()
        {
            var dbContext = new OrderDbContext();
            var folderName = "Orders";
            if (!Directory.Exists(folderName)) Directory.CreateDirectory(folderName);
            foreach (var item in dbContext.SalesOrderHeader.Include("Customer").Include("SalesOrderDetail").Include("SalesOrderDetail.Product").ToList())
            {
                File.WriteAllText(Path.Combine(folderName, item.CustomerID.ToString() + ".json"), JsonConvert.SerializeObject(item));
            }
        }
    }
}
