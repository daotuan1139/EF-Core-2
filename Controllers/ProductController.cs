using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EF_Core_2.Models;
using EF_Core_2.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EF_Core_2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private IProductService _productService;
        public ProductController(IProductService productService){
            _productService = productService;
        }

        [HttpGet]
        public IEnumerable<Product> Get(){
            return _productService.GetList();
        }

        [HttpPost]
        public Product AddProduct(ProductDTO product){
            return _productService.CreateProduct(product);
        }

        [HttpPut]
        public Product UpdateProduct(ProductDTO product){
            return _productService.Update(product);
        }

        [HttpDelete]
        public List<Product> DeleteProduct(ProductDTO product){
            return _productService.Delete(product);
        }

        [HttpGet("FindByID/{id}")]
        public Product DetailProduct(int id){
            return _productService.Detail(id);
        }
    }
}
