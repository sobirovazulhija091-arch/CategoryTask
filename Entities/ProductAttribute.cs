namespace WebApiTask.Entities;

public class ProductAttribute
{
    public int Id {get; set;}

    public int ProductId {get; set;}
    public int AttributeId {get; set;}
    public string Value{get; set;}=null!;
}