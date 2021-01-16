namespace EventoInfrastructure.DTO.Jwt {

    public class JwtDTO {

        /*------------------------ FIELDS REGION ------------------------*/
        public string Token { get; set; }
        public long ExpiryTime { get; set; }

        /*------------------------ METHODS REGION ------------------------*/
        public JwtDTO() {
        }

        public JwtDTO(string token, long expiryTime) {
            Token = token;
            ExpiryTime = expiryTime;
        }

        public override string ToString() {
            return $"{nameof(Token)}: {Token}, " +
                   $"{nameof(ExpiryTime)}: {ExpiryTime}";
        }

    }

}
