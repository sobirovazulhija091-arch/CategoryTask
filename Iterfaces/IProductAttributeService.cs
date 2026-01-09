using WebApiTask.Entities;
using WebApiTask.Responses;
namespace WebApi.Interfaces;
public interface IProductAttributeService
{
    
    Task<Response<string>> AddProductAttributeAsync(ProductAttribute productAttribute);
    Task<List<ProductAttribute>> GetProductAttributeAsync();
    Task<Response<ProductAttribute>> GetProductAttributeByIdAsync(int productattributeId);
    Task<Response<string>> UpdateAsync(ProductAttribute productAttribute);
    Task<Response<string>> DeleteAsync(int productattributeId);
}