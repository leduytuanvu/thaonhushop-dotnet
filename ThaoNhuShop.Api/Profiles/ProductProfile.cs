using AutoMapper;
using ThaoNhuShop.Application.Product.Commands.CreateNew;
using ThaoNhuShop.Contract.Product.Response;
using ThaoNhuShop.Domain.Entities;

namespace ThaoNhuShop.Api.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductResponse, Product>().ReverseMap();
            CreateMap<CreateNewCommand, Product>().ReverseMap();
        }
    }
}