namespace DeliveryWebApi.ViewModels;

public class OrderDetailViewModel
{
    public OrderDetailViewModel()
    {

    }

    public OrderDetailViewModel(int orderDetailId, int productId, int quantity, double total)
    {
        OrderDetailId = orderDetailId;
        ProductId = productId;
        Quantity = quantity;
        Total = total;
    }

    public int OrderDetailId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public double Total { get; set; }
}
