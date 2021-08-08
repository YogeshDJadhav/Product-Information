using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductInformationCore.Model
{
    [Table("ProductInfo")]
    public class ProductInfo
    {
        [Key]
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public float Price { get; set; }
        public string Availability { get; set; }
        public string Brand { get; set; }
    }
    
}
