namespace Shared.BusinessLayer.Config
{
    public class JwtConfig : IConfig
    {
        public static string SectionPath { get; set; } = "Security:Jwt";

        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string SigningKey { get; set; }
        public int ExpirationSeconds { get; set; }
    }
}
