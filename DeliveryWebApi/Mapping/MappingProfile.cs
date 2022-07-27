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

        // Save Order Details mapped
        CreateMap<OrderDetail, SaveOrderDetailViewModel>();
        CreateMap<SaveOrderDetailViewModel, OrderDetail>();

        // Product mapped
        CreateMap<Product, ProductViewModel>();
        CreateMap<ProductViewModel, Product>();

        // Save Product mapped
        CreateMap<Product, SaveProductViewModel>();
        CreateMap<SaveProductViewModel, Product>();

        // Minimal Product mapped
        CreateMap<Product, MinimalProductViewModel>();
        CreateMap<MinimalProductViewModel, Product>();

        // User mapped
        CreateMap<User, UserViewModel>();
        CreateMap<UserViewModel, User>();

        // Minimal User mapped
        CreateMap<User, MinimalUserViewModel>();
        CreateMap<MinimalUserViewModel, User>();
    }
}
