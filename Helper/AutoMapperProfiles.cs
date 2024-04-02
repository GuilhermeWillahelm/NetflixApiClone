using AutoMapper;
using NetflixApiClone.Dtos;
using NetflixApiClone.Models;
using NetflixApiClone.Identity;


namespace NetflixApiClone.Helper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() 
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, LoginDto>().ReverseMap();
            CreateMap<Video, VideoDto>().ReverseMap();
        }
    }
}
