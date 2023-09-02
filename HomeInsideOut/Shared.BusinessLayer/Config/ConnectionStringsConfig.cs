namespace Shared.BusinessLayer.Config
{
    public class ConnectionStringsConfig : IConfig
    {
        public static string SectionPath { get; set; } = "ConnectionStrings";
        public string DbConnectionString { get; set; }
    }
}
