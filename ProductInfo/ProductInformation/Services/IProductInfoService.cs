using ProductInformationCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductInformation.Services
{
    public interface IProductInfoService
    {
        List<ProductInfo> GetProductInfo();
        ProductInfo GetProductInfo(Guid Id);
        ProductInfo CreateProduct(ProductInfo ProductInfo);
        ProductInfo GetEditProduct(Guid Id);
        ProductInfo EditProduct(ProductInfo ProductInfo);
        ProductInfo GetDeleteProduct(Guid Id);
        void DeleteConfirmProduct(Guid Id);
    }
}
