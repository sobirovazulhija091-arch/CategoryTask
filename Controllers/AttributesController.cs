using WebApiTask.Entities;
using WebApiTask.Data;
using WebApiTask.Interfaces;
using WebApiTask.Responses;
using Microsoft.AspNetCore.Mvc;
namespace WebApiTask.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AttributesController(IAttributeService attributeService):ControllerBase
{
      [HttpPost]
      public async Task<Response<string>> AddAttributeAsync(Attributes attribute)
    {
        return await attributeService.AddAttributeAsync(attribute);
    }
    [HttpDelete]
     public async Task<Response<string>> DeleteAttributeAsync(int attributeid)
    {
        return await attributeService.DeleteAttributeAsync(attributeid);
    }
    [HttpPut]
    public async Task<Response<string>> UpdateAttributeAsync(Attributes attribute)
    {
        return await attributeService.UpdateAttributeAsync(attribute); 
    }
    [HttpGet]
    public async Task<List<Attributes>> GetAttributeAsync()
    {
        return await attributeService.GetAttributeAsync();
    }
    [HttpGet("attributes")]
      public async Task<Response<Attributes>> GetAttributeByIdAsync(int attributeId)
    {
        return await attributeService.GetAttributeByIdAsync(attributeId);
    }

}