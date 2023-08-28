using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeInsideOut.BusinessLayer.DTOs
{
    public class UserDTO : BaseDTO
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string HashedPassword { get; set; } = null!;
        public string Salt { get; set; } = null!;
    }
}