using System;
using System.Collections.Generic;

namespace Shared.DataLayer.Models
{
    public partial class User : BaseEntity
    {
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string HashedPassword { get; set; } = null!;
        public string Salt { get; set; } = null!;
    }
}
