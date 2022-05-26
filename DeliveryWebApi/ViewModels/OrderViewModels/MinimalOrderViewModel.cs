namespace DeliveryWebApi.ViewModels.OrderViewModels;

public class MinimalOrderViewModel
{

    public MinimalOrderViewModel()
    {

    }

    public MinimalOrderViewModel(string orderId, string customerFullName, int numberOfDetails, DateTime orderTimestamp, string orderAddress, string orderQrCode, string orderRobot, double totalPrice, EOrderStatus orderStatus, EOrderTracking orderTracking)
    {
        OrderId = orderId;
        CustomerFullName = customerFullName;
        NumberOfDetails = numberOfDetails;
        OrderTimestamp = orderTimestamp;
        OrderAddress = orderAddress;
        OrderQrCode = orderQrCode;
        OrderRobot = orderRobot;
        TotalPrice = totalPrice;
        OrderStatus = orderStatus;
        OrderTracking = orderTracking;
    }

    public string OrderId { get; set; }
    public string CustomerFullName { get; set; }
    public int NumberOfDetails { get; set; }
    public DateTime OrderTimestamp { get; set; }
    public string OrderAddress { get; set; }
    public string OrderQrCode { get; set; }
    public string OrderRobot { get; set; }
    public double TotalPrice { get; set; }
    public EOrderStatus OrderStatus { get; set; }
    public EOrderTracking OrderTracking { get; set; }
}
