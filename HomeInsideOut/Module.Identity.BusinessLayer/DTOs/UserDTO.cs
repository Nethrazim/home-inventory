namespace Module.Identity.BusinessLayer.DTOs
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