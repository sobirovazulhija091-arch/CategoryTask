using WebApi.Interfaces;
using WebApiTask.Data;
using WebApiTask.Entities;
using WebApiTask.Responses;
using Npgsql;
using Dapper;
using System.Net;
public class CategoryAttributeService(ApplicationDbContext dbContext) : ICategoryAttributeService
{
    private readonly ApplicationDbContext context=dbContext;
    public async Task<Response<string>> AddCategoryAttributeAsync(CategoryAttribute categoryAttribute)
    {
       using var conn=context.Connection();
        var query="insert into categoryattributes(categoryid,attributeid,description) values(@categoryid,@attributeid,@description)";
        var res = await conn.ExecuteAsync(query,new{categoryid=categoryAttribute.CategoryId,attributeid=categoryAttribute.AttributeId,description=categoryAttribute.Description});
        return res==0? new Response<string>(HttpStatusCode.InternalServerError,"Can not add")
        :  new Response<string>(HttpStatusCode.OK,"Added successfully");
    }

    public async Task<Response<string>> DeleteAsync(int categoryAttributeId)
    {
         using var conn=context.Connection();
        var query="delete from categoryattributes where id=@Id";
        var res = await conn.ExecuteAsync(query,new{Id=categoryAttributeId});
        return res==0? new Response<string>(HttpStatusCode.NotFound,"Can not fount for delete")
        :  new Response<string>(HttpStatusCode.OK,"delete successfully");
    }

    public async Task<Response<CategoryAttribute>> GetCategoryAttributeByIdAsync(int categoryAttributeId)
    {
        using var conn=context.Connection();
        var query="select * from categoryattributes  where id=@Id";
       var res = await conn.QueryFirstOrDefaultAsync<CategoryAttribute>(query ,new{Id=categoryAttributeId});
               return res==null? new Response<CategoryAttribute>(HttpStatusCode.NotFound,"Can not found Id")
               : new Response<CategoryAttribute>(HttpStatusCode.OK,"Get info successfully"); 
    }

    public async Task<List<CategoryAttribute>> GetCategoryAttributesAsync()
    {
         using var conn=context.Connection();
        var query="select * from  categoryattributes ";
       var res = await conn.QueryAsync<CategoryAttribute>(query);
               return res.ToList();  
    }

    public async Task<Response<string>> UpdateAsync(CategoryAttribute categoryAttribute)
    {
        using var conn=context.Connection();
        var query="update categoryattributes set description=@Description  where id=@Id";
       var res = await conn.ExecuteAsync(query ,categoryAttribute);
               return res==0? new Response<string>(HttpStatusCode.InternalServerError,"Can not update")
               : new Response<string>(HttpStatusCode.OK,"Update successfully");   
    }
}