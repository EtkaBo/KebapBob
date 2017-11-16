using EcommerceService.Services.InterFaces;
using KebapBobModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace KebapBob.Controllers.Api
{
    [RoutePrefix("api/Product")]
    public class ProductController : BaseApiController
    {
        ProductService _service;

        public ProductController()
        {
;            _service = new ProductService();
        }

        [Route("getProducts")]
        [HttpGet]
        public List<ProductViewModel> getProducts()
        {
           return _service.GetProducts();
        }

        [HttpPost]
        [Route("deleteProduct")]
        public void deleteProduct(ProductViewModel deleteProduct)
        {
            _service.DeleteProduct(deleteProduct);
        }

        [HttpPost]
        [Route("updateProduct")]
        public void updateProduct(ProductViewModel updatedProduct)
        {
            _service.UpdateProduct(updatedProduct);
        }

        [HttpPost]
        [Route("createProduct")]
        public void createProduct(ProductViewModel createProduct)
        {
            _service.CreateProduct(createProduct);
        }
    }


}
