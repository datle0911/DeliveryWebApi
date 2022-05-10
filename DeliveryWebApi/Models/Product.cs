namespace DeliveryWebApi.Models;

public class Product
{
#pragma warning disable CS8618
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public string Description { get; set; }
    public byte[] ProductImage { get; set; }
    public double ProductPrice { get; set; }
    public EProductStatus ProductStatus { get; set; }
#pragma warning restore CS8618
}
