using System.Net;
using System.Net.Quic;
using Dapper;
using Microsoft.AspNetCore.Mvc.Routing;
using Npgsql;
using WebApiTask.Data;
using WebApiTask.Entities;
using WebApiTask.Interfaces;
using WebApiTask.Responses;
namespace WebApiTask.Services;
public class CategoryService(ApplicationDbContext _context):ICategoryService
{
    private readonly ApplicationDbContext context = _context;
     public async Task<Response<string>> AddCategoryAsync(Category category)
    {
        using var conn = context.Connection();
        var query = "insert into categories(name, parentcategoryid) values(@name, @parentcategoryid)";
        var res = await conn.ExecuteAsync(query, new {name = category.Name, parentcategoryid=category.ParentCategoryId});
        return res==0
        ? new Response<string>(HttpStatusCode.InternalServerError, "Something went wrong!")
        : new Response<string>(HttpStatusCode.OK, "Category added successfully!");
    }

    public async Task<Response<string>> DeleteAsync(int categoryId)
    {
          try
          {
              using var conn = context.Connection();
              var query="delete from categories where id=@Id";
              var res = await conn.ExecuteAsync(query ,new{Id=categoryId});
               return res==0? new Response<string>(HttpStatusCode.InternalServerError,"Can not delete")
               : new Response<string>(HttpStatusCode.OK,"Deleted successfully");
          }
          catch (System.Exception ex)
          {
              Console.WriteLine(ex);
               return  new Response<string>(HttpStatusCode.InternalServerError,"Internal Server Error");
          }
    }

    public async Task<Response<Category>> GetCategoryByIdAsync(int categoryId)
    {
        using var conn = context.Connection();
        var query = "select * from categories where parentcategoryid=@parentcategoryid";
        var res = await conn.QueryAsync<Category>(query, new{parentcategoryid=categoryId});
        return new Response<Category>(HttpStatusCode.OK, "The data: ", res.ToList());
    }
    public async Task<List<Category>> GetCategorysAsync()
    {
        using var conn = context.Connection();
        var query = "select * from categories";
        var res = await conn.QueryAsync<Category>(query);
        return res.ToList();
    }

    public async Task<Response<string>> UpdateAsync(Category category)
    {
         try
         {
             using var conn = context.Connection();
              var query="update categories set name=@Name,parentcategoryid=@Parentcategoryid where id=@Id";
              var res = await conn.ExecuteAsync(query , category);
               return res==0? new Response<string>(HttpStatusCode.InternalServerError,"Can not update")
               : new Response<string>(HttpStatusCode.OK,"Update successfully");   
         }
         catch (System.Exception ex)
         {
         Console.WriteLine(ex);
               return  new Response<string>(HttpStatusCode.InternalServerError,"Internal Server Error");
         }
    }
      
}