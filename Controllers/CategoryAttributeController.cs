using WebApiTask.Entities;
using WebApiTask.Data;
using WebApiTask.Interfaces;
using WebApiTask.Responses;
using Microsoft.AspNetCore.Mvc;
using WebApi.Interfaces;
namespace WebApiTask.Controllers;
[ApiController]
[Route("api/[controller]")]
public class CategoryAttributeController(ICategoryAttributeService categoryAttributeService):ControllerBase
{
     [HttpPost]
     public async Task<Response<string>> AddCategoryAttributeAsync(CategoryAttribute categoryAttribute)
     {
    return await  categoryAttributeService.AddCategoryAttributeAsync(categoryAttribute);
     }
    [HttpGet]
    public async Task<List<CategoryAttribute>> GetCategoryAttributesAsync()
    {
        return await categoryAttributeService.GetCategoryAttributesAsync();
    }
   [HttpGet("categoryAttributeId")]
   public async Task<Response<CategoryAttribute>> GetCategoryAttributeByIdAsync(int categoryAttributeId)
    {
        return await categoryAttributeService.GetCategoryAttributeByIdAsync(categoryAttributeId);
    }
    [HttpPut]
    public async Task<Response<string>> UpdateAsync(CategoryAttribute categoryAttribute)
    {
        return await categoryAttributeService.UpdateAsync(categoryAttribute);
    }
    [HttpDelete]
    public async   Task<Response<string>> DeleteAsync(int categoryAttributeId)
    {
         return await categoryAttributeService.DeleteAsync(categoryAttributeId);
    }
}
