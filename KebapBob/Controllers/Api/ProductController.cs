using EcommerceService.Services.InterFaces;
using KebapBob.Filters;
using KebapBobModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace KebapBob.Controllers.Api
{
    [ApiAuthenticationFilter]
    [RoutePrefix("api/Product")]
    public class ProductController : BaseApiController
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
;            _service = service
        }

        [Route("getProducts")]
        [HttpGet]
        public List<ProductViewModel> getProducts()
        {
            var userId = CurrentIdentity.UserId;
           return _service.GetProducts(userId);
        }

        [Route("returnProductName")]
        [HttpGet]
        public List<ProductViewModel> returnProductName()
        {
            var userId = CurrentIdentity.UserId;
            return _service.ReturnProductName(userId);
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
            createProduct.UserId = CurrentIdentity.UserId;
            _service.CreateProduct(createProduct);
        }
    }


}
