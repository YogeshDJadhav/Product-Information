using ProductInformation.Services;
using ProductInformationCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ProductInformation.Controllers
{
    public class ProductInfoController : Controller
    {
        private IProductInfoService _ProductInfoService;
        public ProductInfoController(IProductInfoService ProductInfoService)
        {
            _ProductInfoService = ProductInfoService;
        }

        public ActionResult GetProductInfo()
        {
            var ProductInfoList = _ProductInfoService.GetProductInfo();
            return View(ProductInfoList);
        }
        public ActionResult Details(Guid Id)
        {
            var ProductInfo = _ProductInfoService.GetProductInfo(Id);
            if (ProductInfo != null)
            {
                return View(ProductInfo);
            }
            return HttpNotFound();
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(ProductInfo ProductInfo)
        {
            if (!String.IsNullOrEmpty(ProductInfo.ProductName)
                || !String.IsNullOrEmpty(ProductInfo.ProductDescription)
                || ProductInfo.Price.ToString() != null
                || !String.IsNullOrEmpty(ProductInfo.Availability)
                || !String.IsNullOrEmpty(ProductInfo.Brand))
            {
                _ProductInfoService.CreateProduct(ProductInfo);

            }
            return RedirectToAction("GetProductInfo");
        }

        public ActionResult Edit(Guid Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductInfo ProductInfo = _ProductInfoService.GetEditProduct(Id);
            if (ProductInfo == null)
            {
                return HttpNotFound();
            }
            return View(ProductInfo);
        }

        [HttpPost]
        public ActionResult Edit(ProductInfo ProductInfo)
        {
            if (!String.IsNullOrEmpty(ProductInfo.ProductName)
                || !String.IsNullOrEmpty(ProductInfo.ProductDescription)
                || ProductInfo.Price.ToString() != null
                || !String.IsNullOrEmpty(ProductInfo.Availability)
                || !String.IsNullOrEmpty(ProductInfo.Brand))
            {
                _ProductInfoService.EditProduct(ProductInfo);

            }
            return RedirectToAction("GetProductInfo");
        }

        public ActionResult Delete(Guid Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductInfo ProductInfo = _ProductInfoService.GetDeleteProduct(Id);
            if (ProductInfo == null)
            {
                return HttpNotFound();
            }
            return View(ProductInfo);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(Guid Id)
        {
            _ProductInfoService.DeleteConfirmProduct(Id);
            return RedirectToAction("GetProductInfo");
        }
    }
}