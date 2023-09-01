using HomeInsideOut.Common.DataLayer.Repositories;
using HomeInsideOut.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeInsideOut.DataLayer.Repositories
{
    public interface IUserRepository: IGenericRepository<User, int>
    {
    }
}
