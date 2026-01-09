using System;
using WebApiTask.Responses;
using WebApiTask.Entities;
namespace WebApiTask.Interfaces;
public interface IAttributeService
{
      public Task<Response<string>> AddAttributeAsync(Attributes attribute);
      public Task<Response<string>> UpdateAttributeAsync(Attributes attribute);
      public Task<Response<string>> DeleteAttributeAsync(int attributeid);
      public Task<Response<Attributes>> GetAttributeByIdAsync(int attributeId);
      public Task<List<Attributes>> GetAttributeAsync();
     
}