namespace DeliveryWebApi.ViewModels;

public class OrderViewModel
{
    public OrderViewModel(int orderId, int customerId, List<OrderDetailViewModel> details, DateTime orderDate, string orderAddress, string orderQrCode, string orderRobot, double totalPrice, EOrderStatus orderStatus, EOrderTracking orderTracking)
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
    public OrderViewModel()
    {

    }

    public int OrderId { get; set; }
    public int CustomerId { get; set; }
    public List<OrderDetailViewModel> Details { get; set; } = new List<OrderDetailViewModel>();
    public DateTime OrderDate { get; set; }
    public string OrderAddress { get; set; }
    public string OrderQrCode { get; set; }
    public string OrderRobot { get; set; }
    public double TotalPrice { get; set; }
    public EOrderStatus OrderStatus { get; set; }
    public EOrderTracking OrderTracking { get; set; }
}
