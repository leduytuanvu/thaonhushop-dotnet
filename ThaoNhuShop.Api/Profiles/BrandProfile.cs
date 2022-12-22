using AutoMapper;
using ThaoNhuShop.Application.Brand.Commands.CreateNew;
using ThaoNhuShop.Contract.Brand.Request;
using ThaoNhuShop.Contract.Brand.Response;
using ThaoNhuShop.Domain.Entities;

namespace ThaoNhuShop.Api.Profiles
{
    public class BrandProfile : Profile
    {
        public BrandProfile()
        {
            CreateMap<BrandResponse, Brand>().ReverseMap();
            CreateMap<CreateNewBrandRequest, Category>().ReverseMap();
            CreateMap<CreateNewBrandRequest, CreateNewCommand>().ReverseMap();
        }
    }
}