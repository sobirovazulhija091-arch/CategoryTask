using WebApiTask.Entities;
using WebApiTask.Data;
using WebApiTask.Interfaces;
using WebApiTask.Responses;
using Microsoft.AspNetCore.Mvc;
using WebApi.Interfaces;
namespace WebApiTask.Controllers;

[ApiController]
[Route("api/[controller]")]

public class ProductAttributeControllers(IProductAttributeService productAttributeService):ControllerBase
{
    [HttpPost]
     public async Task<Response<string>> AddProductAttributeAsync(ProductAttribute productAttribute)
{
    return await  productAttributeService.AddProductAttributeAsync(productAttribute);
}
    [HttpGet]
    public async Task<List<ProductAttribute>> GetProductAttributeAsync()
    {
        return await productAttributeService.GetProductAttributeAsync();
    }
   [HttpGet("productattributeid")]
   public async Task<Response<ProductAttribute>> GetProductAttributeByIdAsync(int productattributeId)
    {
        return await productAttributeService.GetProductAttributeByIdAsync(productattributeId);
    }
    [HttpPut]
    public async Task<Response<string>> UpdateAsync(ProductAttribute productAttribute)
    {
        return await productAttributeService.UpdateAsync(productAttribute);
    }
    [HttpDelete]
    public async   Task<Response<string>> DeleteAsync(int productattributeId)
    {
         return await productAttributeService.DeleteAsync(productattributeId);
    }
}
 