namespace DeliveryWebApi.Domain.Models;

public class Order
{
    public Order()
    {

    }

    public Order(string orderId, int customerId, Customer customer, List<OrderDetail> details, DateTime orderTimestamp, string orderAddress, string orderQrCode, string orderRobot, double totalPrice, EOrderStatus orderStatus, EOrderTracking orderTracking)
    {
        OrderId = orderId;
        CustomerId = customerId;
        Customer = customer;
        Details = details;
        OrderTimestamp = orderTimestamp;
        OrderAddress = orderAddress;
        OrderQrCode = orderQrCode;
        OrderRobot = orderRobot;
        TotalPrice = totalPrice;
        OrderStatus = orderStatus;
        OrderTracking = orderTracking;
    }

    public string OrderId { get; set; }
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
    public List<OrderDetail> Details { get; set; }
    public DateTime OrderTimestamp { get; set; }
    public string OrderAddress { get; set; }
    public string OrderQrCode { get; set; }
    public string OrderRobot { get; set; }
    public double TotalPrice { get; set; }
    public EOrderStatus OrderStatus { get; set; }
    public EOrderTracking OrderTracking { get; set; }
}
