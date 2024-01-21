using AutoMapper;
using Eshop.Application.Shared;
using Eshop.Domain.CheckoutCart;
using Eshop.Domain.Orders;
using Eshop.Domain.Shared;

namespace Eshop.Application.Mappers
{
    internal class CustomProfile : Profile
    {
        public CustomProfile()
        {
            CreateMap<OrderProductData, ProductDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ProductId))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity));

            CreateMap<ProductDto, OrderProductData>()
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity));

            CreateMap<Order, OrderDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products));

            CreateMap<OrderDto, Order>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products));

            CreateMap<OrderProduct, ProductDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity));

            CreateMap<Customer, CustomerDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<CustomerDto, Customer>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<Cart, OrderDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products));

            CreateMap<OrderDto, Cart>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products));

            CreateMap<CartProduct, ProductDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity));

            CreateMap<ProductDto, CartProduct>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity));

            CreateMap<Cart, CheckoutCartDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.CustomerId))
                .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products));

        }
    }
}
