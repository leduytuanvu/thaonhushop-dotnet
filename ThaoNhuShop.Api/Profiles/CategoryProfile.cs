using AutoMapper;
using ThaoNhuShop.Application.Category.Commands.CreateNew;
using ThaoNhuShop.Contract.Category.Request;
using ThaoNhuShop.Contract.Category.Response;
using ThaoNhuShop.Domain.Entities;

namespace ThaoNhuShop.Api.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryResponse, Category>().ReverseMap();
            CreateMap<CreateNewCategoryRequest, Category>().ReverseMap();
            CreateMap<CreateNewCategoryRequest, CreateNewCommand>().ReverseMap();
            CreateMap<CreateNewCommand, Category>().ReverseMap();
        }
    }
}