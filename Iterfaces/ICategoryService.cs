using WebApiTask.Entities;
using WebApiTask.Responses;

public interface ICategoryService
{
    
    Task<Response<string>> AddCategoryAsync(Category category);
    Task<List<Category>> GetCategorysAsync();
    Task<Response<Category>> GetCategoryByIdAsync(int categoryId);
    Task<Response<string>> UpdateAsync(Category category);
    Task<Response<string>> DeleteAsync(int categoryId);
}