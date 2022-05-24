using AutoMapper;

namespace DeliveryWebApi.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Customer mapped
        CreateMap<Customer, CustomerViewModel>();
        CreateMap<CustomerViewModel, Customer>();

        // Order mapped
        CreateMap<Order, OrderViewModel>();
        CreateMap<OrderViewModel, Order>();

        // Save Order mapped
        CreateMap<Order, SaveOrderViewModel>();
        CreateMap<SaveOrderViewModel, Order>();

        // Order Details mapped
        CreateMap<OrderDetail, OrderDetailViewModel>();
        CreateMap<OrderDetailViewModel, OrderDetail>();

        // Product mapped
        CreateMap<Product, ProductViewModel>();
        CreateMap<ProductViewModel, Product>();

        // User mapped
        CreateMap<User, UserViewModel>();
        CreateMap<UserViewModel, User>();
    }
}
