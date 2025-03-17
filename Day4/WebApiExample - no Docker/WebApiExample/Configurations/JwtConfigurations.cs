namespace WebApiExample.Configurations
{
    public class JwtConfigurations
    {
        public string Issuer { get; set; }

        public string Key { get; set; }

        public string Audience { get; set; }

        public string Subject { get; set; }

        public int Experation { get; set; }
    }
}
