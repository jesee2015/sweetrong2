using SweetRong2.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SweetRong2.Domain;

namespace SweetRong2.Web.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/
        private IProductService _productService;
        public ProductController(IProductService prodcutService)
        {
            _productService = prodcutService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddProductView()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(Product product)
        {
            product.CreateDate = DateTime.Now;
            product.PId = Guid.NewGuid();
            _productService.AddEntity(product);
            return View();
        }

        public ActionResult ProductList()
        {
            var products = _productService.LoadEntities((p) => 1==1);
            //var products = _productService.LoadPageEntities<Product>(1, 10, out totle, (p) => true, true, (p) => p);
            return View(products);
        }
    }
}
