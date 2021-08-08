using ProductInformationCore;
using ProductInformationCore.Data.Container;
using ProductInformationCore.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ProductInformation.Services
{
    public class ProductInfoService : IProductInfoService
    {
        private readonly IContextFactory _contextFactory;
        public ProductInfoService(IContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public List<ProductInfo> GetProductInfo()
        {
            using (var context = _contextFactory.GetContaxt())
            {
                return context.ProductInfo.ToList();
            }
        }

        public ProductInfo GetProductInfo(Guid Id)
        {
            using (var context = _contextFactory.GetContaxt())
            {
                if (Id == null)
                {                    
                }
                return context.ProductInfo.Where(x => x.Id == Id).FirstOrDefault();
            }
        }        
        public ProductInfo CreateProduct(ProductInfo ProductInfo)
        {
            using (var context = _contextFactory.GetContaxt())
            {                
                var ProductInfoContext = new ProductInfo
                {
                    Id = Guid.NewGuid(),
                    ProductName = ProductInfo.ProductName,
                    ProductDescription = ProductInfo.ProductDescription,
                    Price = ProductInfo.Price,
                    Availability = ProductInfo.Availability,
                    Brand = ProductInfo.Brand
                };
                context.ProductInfo.Add(ProductInfoContext);
                context.SaveChanges();               
            }
            return ProductInfo;
        }

        public ProductInfo GetEditProduct(Guid Id)
        {
            using (var context = _contextFactory.GetContaxt())
            {
                ProductInfo ProductInfo = context.ProductInfo.Find(Id);
                return ProductInfo;
            }            
        }

        public ProductInfo EditProduct(ProductInfo ProductInfo)
        {
            using (var context = _contextFactory.GetContaxt())
            {
                context.Entry(ProductInfo).State = EntityState.Modified;
                context.SaveChanges();
            }
            return ProductInfo;
        }

        public ProductInfo GetDeleteProduct(Guid Id)
        {
            using (var context = _contextFactory.GetContaxt())
            {
                ProductInfo ProductInfo = context.ProductInfo.Find(Id);                              
                return ProductInfo;
            }
        }

        public void DeleteConfirmProduct(Guid Id)
        {
            using (var context = _contextFactory.GetContaxt())
            {
                ProductInfo ProductInfo = context.ProductInfo.Find(Id);
                if (ProductInfo != null)
                {
                    context.ProductInfo.Remove(ProductInfo);
                    context.SaveChanges();
                }               
            }            
        }
    }
}