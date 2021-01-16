namespace EventoInfrastructure.Settings {

    public class JwtSettings {

        /*------------------------ FIELDS REGION ------------------------*/
        public string SecurityKey { get; set; }
        public string ApplicationUrl { get; set; }
        public int ExpiryTimeInMinutes { get; set; }

        /*------------------------ METHODS REGION ------------------------*/
        public JwtSettings() {
        }

        public JwtSettings(string securityKey, string applicationUrl, int expiryTimeInMinutes) {
            SecurityKey = securityKey;
            ApplicationUrl = applicationUrl;
            ExpiryTimeInMinutes = expiryTimeInMinutes;
        }

        public override string ToString() {
            return $"{nameof(SecurityKey)}: {SecurityKey}, " +
                   $"{nameof(ApplicationUrl)}: {ApplicationUrl}, " +
                   $"{nameof(ExpiryTimeInMinutes)}: {ExpiryTimeInMinutes}";
        }

    }

}
