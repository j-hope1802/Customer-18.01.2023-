using Domain.Dto;
using Domain.Entity;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController:ControllerBase
{
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
                _productService = productService;
        }

        [HttpGet]
        public List<ProductDto> GetProducts()
        {
                return _productService.GetProducts();
        }
        
        [HttpGet("searchbyname")]
        public List<ProductDto> GetProductsByName([FromQuery] string name)
        {
                return _productService.GetProductByName(name);
        }
        
        [HttpPost]
        public bool AddProducts(AddProductDto product)
        {
                _productService.AddProducts(product);
                return true;
        }
        [HttpPut]
        public bool UpdateProduct(AddProductDto product)
        {
        _productService.UpdateProduct(product);
        return true;
        }
        [HttpDelete]
        public bool DeleteProducts (int id)
        {
            _productService.DeleteProducts( id);
            return true;
        } 
         [HttpGet("GetBYID")]
        public Product  GetById(int id){
            return _productService.GetProductById(id);
        }
}