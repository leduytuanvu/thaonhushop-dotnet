using AutoMapper;
using ThaoNhuShop.Application.Authentication.Commands.Register;
using ThaoNhuShop.Application.Authentication.Common;
using ThaoNhuShop.Application.Authentication.Queries.Login;
using ThaoNhuShop.Contract.Authentication.Login;
using ThaoNhuShop.Contract.Authentication.Register;

namespace ThaoNhuShop.Api.Profiles
{
    public class AuthenticationProfile : Profile
    {
        public AuthenticationProfile()
        {
            CreateMap<RegisterResponse, AuthenticationResult>()
                .ForPath(des => des.User.Id, act => act.MapFrom(src => src.Id))
                .ForPath(des => des.User.Phone, act => act.MapFrom(src => src.Phone))
                .ForPath(des => des.User.FullName, act => act.MapFrom(src => src.FullName))
                .ForPath(des => des.User.Email, act => act.MapFrom(src => src.Email))
                .ForPath(des => des.User.Avatar, act => act.MapFrom(src => src.Avatar))      
                .ForMember(des => des.Token, act => act.MapFrom(src => src.Token));
            CreateMap<AuthenticationResult, RegisterResponse>()
                .ForPath(des => des.Id, act => act.MapFrom(src => src.User.Id))
                .ForPath(des => des.Phone, act => act.MapFrom(src => src.User.Phone))
                .ForPath(des => des.FullName, act => act.MapFrom(src => src.User.FullName))
                .ForPath(des => des.Email, act => act.MapFrom(src => src.User.Email))
                .ForPath(des => des.Avatar, act => act.MapFrom(src => src.User.Avatar))
                .ForMember(des => des.Token, act => act.MapFrom(src => src.Token));
            // CreateMap<AuthenticationResult, RegisterResponse>()
            //     .ForMember(des => des.Token, act => act.MapFrom(src => src.Token))
            //     .ForMember(des => new RegisterResponse(des.Id, des.Phone, des.FullName, des.Email, des.Avatar, des.Token), act => act.MapFrom(src => src.User));
            // CreateMap<AuthenticationResult, LoginResponse>()
            //     .ForMember(des => des.Token, act => act.MapFrom(src => src.Token))
            //     .ForMember(des => des.Id, act => act.MapFrom(src => src.User.Id))
            //     .ForMember(des => des.Phone, act => act.MapFrom(src => src.User.Phone))
            //     .ForMember(des => des.FullName, act => act.MapFrom(src => src.User.FullName))
            //     .ForMember(des => des.Email, act => act.MapFrom(src => src.User.Email))
            //     .ForMember(des => des.Avatar, act => act.MapFrom(src => src.User.Avatar)).ReverseMap();
            CreateMap<RegisterCommand, RegisterRequest>().ReverseMap();
            CreateMap<LoginQuery, LoginRequest>().ReverseMap();
        }
    }
}