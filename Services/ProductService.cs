using Dapper;
using WebApiTask.Interfaces;
using WebApiTask.Data;
using WebApiTask.Entities;
using WebApiTask.Responses;
using System.Net;
namespace WebApiTask.Services;
public class ProductService(ApplicationDbContext dbContext):IProductService
{
      private readonly ApplicationDbContext context=dbContext;
    public async Task<Response<string>> AddProductAsync(Product product)
    {
         using var conn = context.Connection();
         var query="insert into products(name,price, description, model,createdat,isdeleted) values(@name,@price,@description,@model,@createdat,@isdeleted)";
         var res= await conn.ExecuteAsync(query,new{name=product.Name,price=product.Price,description=product.Description,model=product.Model,createdat = DateTime.UtcNow,isdeleted=product.IsDeleted});
         return res==0? new Response<string>(HttpStatusCode.InternalServerError,"Can not Add")
         : new Response<string>(HttpStatusCode.OK,"Added successfully");
         
    }
    public async Task<Response<string>> DeleteAsync(int productId)
    {
        using var conn = context.Connection();
        var query="delete from products where id=@Id";
        var res= await conn.ExecuteAsync(query,new{Id=productId});
        return res==0? new Response<string>(HttpStatusCode.InternalServerError,"Can not delete")
        : new Response<string>(HttpStatusCode.OK,"Deleted successfully");
    }
    public async Task<Response<Product>> GetProductByIdAsync(int productId)
    {
        using var conn=context.Connection();
        var query="select * from products where id=@Id";
        var selectByid= await conn.QueryFirstOrDefaultAsync<Product>(query,new{Id=productId});
                 return selectByid==null
                  ? new Response<Product>(HttpStatusCode.NotFound,"Product not found !")
                  : new Response<Product>(HttpStatusCode.OK, "Product  found !", selectByid);
    }
    public async Task<List<Product>> GetProductsAsync()
    {
        using var conn=context.Connection();
        var query="select * from products";
        var selectByid= await conn.QueryAsync<Product>(query);
        return selectByid.ToList();
        
    }
    public async Task<Response<string>> UpdateAsync(Product product)
    {
       using var conn = context.Connection();
       var query="update products set name=@Name,price=@Price,description=@Description,model=@Model,isdeleted=@IsDeleted where id=@Id";
       var res = await conn.ExecuteAsync(query ,product);
         return res==0? new Response<string>(HttpStatusCode.InternalServerError,"Can not update")
               : new Response<string>(HttpStatusCode.OK,"Update successfully");    
    }
}