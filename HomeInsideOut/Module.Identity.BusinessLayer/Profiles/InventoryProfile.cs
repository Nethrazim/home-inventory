using AutoMapper;
using Module.Identity.BusinessLayer.DTOs;
using Shared.DataLayer.Models;

namespace Module.Identity.BusinessLayer.Profiles
{
    public class InventoryProfile : Profile
    {
        public InventoryProfile()
        {
            CreateMap<Inventory, InventoryDTO>().ReverseMap();
        }
    }
}
