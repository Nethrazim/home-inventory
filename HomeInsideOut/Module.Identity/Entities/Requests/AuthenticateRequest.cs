﻿using System.ComponentModel.DataAnnotations;

namespace Module.Identity.Entities.Model.Requests
{
    public class AuthenticateRequest
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
