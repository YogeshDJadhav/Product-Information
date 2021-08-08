using ProductInformationCore.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductInformationCore
{
    public class ProductInfoDbContext: DbContext
    {
        public ProductInfoDbContext(string connectionString) : base(connectionString)
        {
                  
        }
        public DbSet<ProductInfo> ProductInfo { get; set; }
    }
}
