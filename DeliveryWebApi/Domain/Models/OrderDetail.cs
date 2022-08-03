namespace DeliveryWebApi.Domain.Models;

public class OrderDetail
{
    public OrderDetail()
    {

    }
    public OrderDetail(string orderId, int productId, Product product, int quantity, double total)
    {
        OrderId = orderId;
        ProductId = productId;
        Product = product;
        Quantity = quantity;
        Total = total;
    }

    public string OrderId { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }
    public int Quantity { get; set; }
    public double Total { get; set; }
}
