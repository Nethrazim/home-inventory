using System.ComponentModel.DataAnnotations;

namespace HomeInsideOut.Api.Entities.Requests
{
    public class AuthenticateRequest
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
