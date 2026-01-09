using System;

namespace WebApiTask.Entities;

public class CategoryAttribute
{
    public int Id {get; set;}
    public int CategoryId {get; set;}
    public int AttributeId {get; set;}
    public string Description{get;set;}=null!;
}