namespace Module.Identity.Entities.Model
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
