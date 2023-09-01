using HomeInsideOut.BusinessLayer.DTOs;
using HomeInsideOut.Common.BusinessLayer.Services;
using HomeInsideOut.DataLayer.Models;

namespace HomeInsideOut.BusinessLayer.Services
{
    public interface IUserService: IGenericService<UserDTO, User, int>
    {
    }
}