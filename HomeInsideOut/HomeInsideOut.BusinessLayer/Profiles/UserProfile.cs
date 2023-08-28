using AutoMapper;
using HomeInsideOut.BusinessLayer.DTOs;
using HomeInsideOut.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeInsideOut.BusinessLayer.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile() {
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}
