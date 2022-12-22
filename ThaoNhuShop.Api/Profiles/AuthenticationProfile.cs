using AutoMapper;
using ThaoNhuShop.Application.Authentication.Commands.Register;
using ThaoNhuShop.Application.Authentication.Common;
using ThaoNhuShop.Application.Authentication.Queries.Login;
using ThaoNhuShop.Contract.Authentication.Request;
using ThaoNhuShop.Contract.Authentication.Response;

namespace ThaoNhuShop.Api.Profiles
{
    public class AuthenticationProfile : Profile
    {
        public AuthenticationProfile()
        {        
            CreateMap<AuthenticationResult, AuthenticationResponse>()
                .ForMember(des => des.Id, act => act.MapFrom(src => src.User.Id))
                .ForMember(des => des.Phone, act => act.MapFrom(src => src.User.Phone))
                .ForMember(des => des.FullName, act => act.MapFrom(src => src.User.FullName))
                .ForMember(des => des.Email, act => act.MapFrom(src => src.User.Email))
                .ForMember(des => des.Avatar, act => act.MapFrom(src => src.User.Avatar))
                .ForMember(des => des.Gender, act => act.MapFrom(src => src.User.Gender))
                .ForMember(des => des.Token, act => act.MapFrom(src => src.Token)).ReverseMap();

            CreateMap<RegisterCommand, RegisterRequest>().ReverseMap();
            
            CreateMap<LoginQuery, LoginRequest>().ReverseMap();
        }
    }
}