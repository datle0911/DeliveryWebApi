namespace DeliveryWebApi.ViewModels.OrderViewModels;

public class SaveOrderDetailViewModel
{
    public SaveOrderDetailViewModel()
    {

    }

    public SaveOrderDetailViewModel(int productId, int quantity, double total)
    {
        ProductId = productId;
        Quantity = quantity;
        Total = total;
    }

    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public double Total { get; set; }
}
