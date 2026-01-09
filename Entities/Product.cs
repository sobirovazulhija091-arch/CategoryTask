using System;

namespace WebApiTask.Entities;

public class Product
{
    public int Id {get; set;}
    public string Name {get; set;}=null!;
    public decimal Price {get; set;}
    public string? Description {get; set;}
    public string? Model {get;set;}
    public DateTime CreatedAt {get; set;} = DateTime.UtcNow;
    public int CategoryId {get; set;}
    public bool IsDeleted {get; set;}=false;

}