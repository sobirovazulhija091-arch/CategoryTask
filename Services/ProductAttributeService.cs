using System.Net;
using System.Net.Quic;
using Dapper;
using Microsoft.AspNetCore.Mvc.Routing;
using Npgsql;
using WebApi.Interfaces;
using WebApiTask.Data;
using WebApiTask.Entities;
using WebApiTask.Interfaces;
using WebApiTask.Responses;
namespace WebApiTask.Services;
public class ProductAttributeService(ApplicationDbContext dbContext) : IProductAttributeService
{
    private readonly ApplicationDbContext context=dbContext;

    public async Task<Response<string>> AddProductAttributeAsync(ProductAttribute productAttribute)
    {
        using var conn=context.Connection();
        var query="insert into productattributes(productid,attributeid,value) values(@productid,@attributeid,@value)";
        var res = await conn.ExecuteAsync(query,new{productid=productAttribute.ProductId,attributeid=productAttribute.AttributeId,value=productAttribute.Value});
        return res==0? new Response<string>(HttpStatusCode.InternalServerError,"Can not add")
        :  new Response<string>(HttpStatusCode.OK,"Added successfully");
    }

    public async Task<Response<string>> DeleteAsync(int productattributeId)
    {
           using var conn=context.Connection();
        var query="delete from productattributes where id=@Id";
        var res = await conn.ExecuteAsync(query,new{Id=productattributeId});
        return res==0? new Response<string>(HttpStatusCode.NotFound,"Can not fount for delete")
        :  new Response<string>(HttpStatusCode.OK,"delete successfully");
    }

    public async Task<List<ProductAttribute>> GetProductAttributeAsync()
    {
         using var conn=context.Connection();
        var query="select * from productattributes ";
       var res = await conn.QueryAsync<ProductAttribute>(query);
               return res.ToList();  
    }

    public async Task<Response<ProductAttribute>> GetProductAttributeByIdAsync(int productattributeId)
    {
         using var conn=context.Connection();
        var query="select * from productattributes  where id=@Id";
       var res = await conn.QueryFirstOrDefaultAsync<ProductAttribute>(query ,new{Id=productattributeId});
               return res==null? new Response<ProductAttribute>(HttpStatusCode.NotFound,"Can not found Id")
               : new Response<ProductAttribute>(HttpStatusCode.OK,"Get info  successfully");   
    }

    public async Task<Response<string>> UpdateAsync(ProductAttribute productattribute)
    {  
        using var conn=context.Connection();
        var query="update productattributes set value=@Value  where id=@Id";
       var res = await conn.ExecuteAsync(query ,productattribute);
               return res==0? new Response<string>(HttpStatusCode.InternalServerError,"Can not update")
               : new Response<string>(HttpStatusCode.OK,"Update successfully");   
    }
}