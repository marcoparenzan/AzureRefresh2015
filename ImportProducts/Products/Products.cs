using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Import.Products
{
    static class Products
    {
        public static void Import()
        {
            var dbContext = new ProductDbContext();
            var folderName = "Products";
            if (!Directory.Exists(folderName)) Directory.CreateDirectory(folderName);
            foreach (var item in dbContext.Product.Include("SalesOrderDetail").Include("SalesOrderDetail.SalesOrderHeader").Include("ProductCategory").Include("ProductModel").ToList())
            {
                File.WriteAllText(Path.Combine(folderName, item.ProductID.ToString() + ".json"), JsonConvert.SerializeObject(item));
            }
        }
    }
}
