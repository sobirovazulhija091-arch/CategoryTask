using WebApiTask.Data;
using WebApiTask.Interfaces;
using WebApiTask.Entities;
using WebApiTask.Responses;
using Dapper;
using System.Net;
namespace WebApiTask.Services;

public class AttributeService(ApplicationDbContext dbContext) : IAttributeService
{
    private readonly ApplicationDbContext context=dbContext;
    public async Task<Response<string>> AddAttributeAsync(Attributes attribute)
    {
         using var conn=context.Connection();
         var query="insert into attributes(name) values(@name)";
        var res = await conn.ExecuteAsync(query, new {name = attribute.Name});
        return res==0? new Response<string>(HttpStatusCode.InternalServerError,"Can not add")
        : new Response<string>(HttpStatusCode.OK,"Added successfully");
    }

    public async Task<Response<string>> DeleteAttributeAsync(int attributeid)
    {
          using var conn=context.Connection();
           var query="delete from attributes where id=@Id";
           var res = await conn.ExecuteAsync(query, new {Id=attributeid});
        return res==0? new Response<string>(HttpStatusCode.InternalServerError,"Can not delete")
        : new Response<string>(HttpStatusCode.OK,"Deleted successfully");
    }

    public async Task<List<Attributes>> GetAttributeAsync()
    {
       using  var conn= context.Connection();
       var query="select * from attributes";
       var res=await conn.QueryAsync<Attributes>(query);
       return res.ToList();
    }

    public async Task<Response<Attributes>> GetAttributeByIdAsync(int attributeId)
    {
        using  var conn= context.Connection();
       var query="select * from attributes where id=Id";
       var res=await conn.QueryFirstOrDefaultAsync<Attributes>(query,new{Id=attributeId});
       return res==null
                  ? new Response<Attributes>(HttpStatusCode.NotFound,"Attribute not found !")
                  : new Response<Attributes>(HttpStatusCode.OK, "Attribute  found !", res);
    }

    public async Task<Response<string>> UpdateAttributeAsync(Attributes attribute)
    {
         using var conn=context.Connection();
           var query="update  attributes set name=@Name where id=@Id";
           var res = await conn.ExecuteAsync(query, attribute);
        return res==0? new Response<string>(HttpStatusCode.InternalServerError,"Can not update")
        : new Response<string>(HttpStatusCode.OK," Update successfully");
    }
}