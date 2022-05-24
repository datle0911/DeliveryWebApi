namespace DeliveryWebApi.ViewModels.OrderDetailViewModels;

public class OrderDetailViewModel
{
    public OrderDetailViewModel()
    {

    }

    public OrderDetailViewModel(ProductViewModel product, int quantity, double total)
    {
        Product = product;
        Quantity = quantity;
        Total = total;
    }

    public ProductViewModel Product { get; set; } = new ProductViewModel();
    public int Quantity { get; set; }
    public double Total { get; set; }
}
