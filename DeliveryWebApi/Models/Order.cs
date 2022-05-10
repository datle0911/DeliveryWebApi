namespace DeliveryWebApi.Models;

public class Order
{
    public Order()
    {

    }
    public Order(int orderId, int customerId, List<OrderDetail> details, DateTime orderDate, string orderAddress, string orderQrCode, string orderRobot, double totalPrice, EOrderStatus orderStatus, EOrderTracking orderTracking)
    {
        OrderId = orderId;
        CustomerId = customerId;
        Details = details;
        OrderDate = orderDate;
        OrderAddress = orderAddress;
        OrderQrCode = orderQrCode;
        OrderRobot = orderRobot;
        TotalPrice = totalPrice;
        OrderStatus = orderStatus;
        OrderTracking = orderTracking;
    }
#pragma warning disable CS8618
    public int OrderId { get; set; }
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
    public List<OrderDetail> Details { get; set; }
    public DateTime OrderDate { get; set; }
    public string OrderAddress { get; set; }
    public string OrderQrCode { get; set; }
    public string OrderRobot { get; set; }
    public double TotalPrice { get; set; }
    public EOrderStatus OrderStatus { get; set; }
    public EOrderTracking OrderTracking { get; set; }
#pragma warning restore CS8618
}
