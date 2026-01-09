using Microsoft.AspNetCore.Mvc;
using WebApiTask.Entities;
using WebApiTask.Interfaces;
using WebApiTask.Responses;
using WebApiTask.Services;

namespace WebApiTask.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController(IProductService productService):ControllerBase
{
     [HttpPost]
        public async Task<Response<string>> AddProductAsync(Product product)
    {
        return await productService.AddProductAsync(product);
    }
         [HttpGet]
    public async Task<List<Product>> GetProductsAsync()
    {
        return await productService.GetProductsAsync();
    }
         [HttpGet("productId")]
    public async Task<Response<Product>> GetProductByIdAsync(int productId)
    {
        return await productService.GetProductByIdAsync(productId);
    }
    [HttpPut]
    public async Task<Response<string>> UpdateAsync(Product product)
    {
        return await productService.UpdateAsync(product);
    }
    [HttpDelete]
    public async Task<Response<string>> DeleteAsync(int productId)
    {
        return await productService.DeleteAsync(productId);
    }
}
