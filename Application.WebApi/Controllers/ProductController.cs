using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Application.Data;
using Application.Service.Services;

namespace Application.WebApi.Controllers
{
    public class ProductController : ApiController
    {
        private readonly IProductService _productService = new ProductService();
        //Convention Routing  localhost /Api/Products/GetProducts
        [HttpGet]
        [ActionName("GetProducts")]
        public IEnumerable<Product> Get()
        {
            return _productService.GetProducts();
        }
        //Attribute Routing localhost /GetProduct/ {id}
        [HttpGet]
        [Route("GetProduct/{id}")]
        public IHttpActionResult Get(int id)
        {
            var product = _productService.GetProduct(id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }
        [HttpPost]
        public IHttpActionResult Post(Product product)
        {
            var isSaved=_productService.SaveProduct(product);
            if (isSaved)
                return Ok();
            return BadRequest();
        }
        [HttpPut]
        public IHttpActionResult Put(Product product)
        {
            var isUpdated = _productService.UpdateProduct(product.Id,product);
            if (isUpdated)
                return Ok();
            return BadRequest();
        }
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var isDeleted = _productService.DeleteProduct(id);
            if (isDeleted)
                return Ok();
            return BadRequest();
        }
    }
}
