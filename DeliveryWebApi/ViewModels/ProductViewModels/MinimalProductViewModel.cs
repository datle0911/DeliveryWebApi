namespace DeliveryWebApi.ViewModels.ProductViewModels;

public class MinimalProductViewModel
{
    public MinimalProductViewModel(int productId, string productName, string description, double productPrice, EProductStatus productStatus)
    {
        ProductId = productId;
        ProductName = productName;
        Description = description;
        ProductPrice = productPrice;
        ProductStatus = productStatus;
    }

    public MinimalProductViewModel()
    {

    }

    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public string Description { get; set; }
    public double ProductPrice { get; set; }
    public EProductStatus ProductStatus { get; set; }
}
