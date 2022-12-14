using AutoMapper;
using ThaoNhuShop.Contract.Authentication.Register;
using ThaoNhuShop.Domain.Entities;

namespace ThaoNhuShop.Api.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, RegisterRequest>().ReverseMap();
        }
    }
}