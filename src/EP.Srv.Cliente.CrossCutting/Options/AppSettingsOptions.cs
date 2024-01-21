namespace EP.Srv.Cliente.CrossCutting.Options
{
    public class AppSettingsOptions
    {
        public string DbConnectionString { get; set; } = string.Empty;
        public string MySqlVersion { get; set; } = string.Empty;
    }

    public class JwtOptions
    {
        public string Issuer { get; set; } = string.Empty;
        public string Audience { get; set; } = string.Empty;
        public string Key { get; set; } = string.Empty;
        public string AccessTokenExpirationInMinutes { get; set; } = string.Empty;
        public string RefreshTokenExpirationInDays { get; set; } = string.Empty;
    }
}
