using AutoMapper;
using OrderManagementApi.DataAccess.Entities;
using OrderManagementApi.DTO.BedType.Request;
using OrderManagementApi.DTO.Order.Dto;
using OrderManagementApi.DTO.OrderItem.Dto;
using OrderManagementApi.DTO.OrderItem.Request;
using OrderManagementApi.DTO.Product.Dto;
using OrderManagementApi.DTO.Product.Request;
using OrderManagementApi.DTO.User.Dto;
using OrderManagementApi.DTO.User.Request;

namespace OrderManagementApi.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Order Mappings
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<OrderSaveRequest, Order>();

            // OrderItem Mappings
            CreateMap<OrderItem, OrderItemDto>().ReverseMap();
            CreateMap<OrderItemSaveRequest, OrderItem>();

            // Product Mappings
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<ProductSaveRequest, Product>();

            // User Mappings
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<UserSaveRequest, User>();
        }
    }
} 