using AutoMapper;
using Module.Identity.BusinessLayer.DTOs;
using Shared.DataLayer.Models;

namespace Module.Identity.BusinessLayer.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}
