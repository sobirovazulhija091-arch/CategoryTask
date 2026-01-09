using Microsoft.AspNetCore.Mvc;
using WebApiTask.Entities;
using WebApiTask.Interfaces;
using WebApiTask.Responses;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController(ICategoryService categoryService) : ControllerBase
{
    [HttpGet]
    public async Task<List<Category>> GetCategoriesAsync()
    {
        return await categoryService.GetCategorysAsync();
    }

    [HttpPost]
    public async Task<Response<string>> AddAsync(Category category)
    {
        return await categoryService.AddCategoryAsync(category);
    }

    [HttpGet("{categoryId}")]
    public async Task<Response<Category>> GetCategorySubcategories(int categoryId)
    {
        return await categoryService.GetCategoryByIdAsync(categoryId);
    }
   [HttpDelete]
     public async Task<Response<string>> DeleteAsync(int categoryId)
    {
        return await categoryService.DeleteAsync(categoryId);
    }
    [HttpPut]
     public async Task<Response<string>> UpdateAsync(Category category)
    {
        return await categoryService.UpdateAsync(category);
    }
}