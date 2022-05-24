﻿namespace DeliveryWebApi.ViewModels.OrderViewModels;

public class SaveOrderViewModel
{
    public SaveOrderViewModel(string orderId, int customerId, List<OrderDetailViewModel> details, DateTime orderTimestamp, string orderAddress, string orderQrCode, string orderRobot, double totalPrice, EOrderStatus orderStatus, EOrderTracking orderTracking)
    {
        OrderId = orderId;
        CustomerId = customerId;
        Details = details;
        OrderTimestamp = orderTimestamp;
        OrderAddress = orderAddress;
        OrderQrCode = orderQrCode;
        OrderRobot = orderRobot;
        TotalPrice = totalPrice;
        OrderStatus = orderStatus;
        OrderTracking = orderTracking;
    }
    public SaveOrderViewModel()
    {

    }

    public string OrderId { get; set; }
    public int CustomerId { get; set; }
    public List<OrderDetailViewModel> Details { get; set; } = new List<OrderDetailViewModel>();
    public DateTime OrderTimestamp { get; set; }
    public string OrderAddress { get; set; }
    public string OrderQrCode { get; set; }
    public string OrderRobot { get; set; }
    public double TotalPrice { get; set; }
    public EOrderStatus OrderStatus { get; set; }
    public EOrderTracking OrderTracking { get; set; }
}
