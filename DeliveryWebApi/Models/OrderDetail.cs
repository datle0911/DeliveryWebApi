namespace DeliveryWebApi.Models;

public class OrderDetail
{
    public OrderDetail()
    {

    }
    public OrderDetail(int orderDetailId, int orderId, int productId, Product product, int quantity, double total)
    {
        OrderDetailId = orderDetailId;
        OrderId = orderId;
        ProductId = productId;
        Product = product;
        Quantity = quantity;
        Total = total;
    }
#pragma warning disable CS8618
    public int OrderDetailId { get; set; }
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }
    public int Quantity { get; set; }
    public double Total { get; set; }
#pragma warning restore CS8618
}
