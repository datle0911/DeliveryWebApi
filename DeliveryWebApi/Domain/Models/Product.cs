namespace DeliveryWebApi.Domain.Models;

public class Product
{
    public Product()
    {

    }
    public Product(string productName, string description, byte[] productImage, double productPrice, EProductStatus productStatus)
    {
        ProductName = productName;
        Description = description;
        ProductImage = productImage;
        ProductPrice = productPrice;
        ProductStatus = productStatus;
    }

    public Product(int productId, string productName, string description, byte[] productImage, double productPrice, EProductStatus productStatus)
    {
        ProductId = productId;
        ProductName = productName;
        Description = description;
        ProductImage = productImage;
        ProductPrice = productPrice;
        ProductStatus = productStatus;
    }
#pragma warning disable CS8618
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public string Description { get; set; }
    public byte[] ProductImage { get; set; }
    public double ProductPrice { get; set; }
    public EProductStatus ProductStatus { get; set; }
#pragma warning restore CS8618
}
