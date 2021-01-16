using EventoCore.Domain;

namespace EventoInfrastructure.DTO.Jwt {

    public class TokenDTO : JwtDTO {

        /*------------------------ FIELDS REGION ------------------------*/
        public UserRole Role { get; set; }

        /*------------------------ METHODS REGION ------------------------*/
        public TokenDTO() {
        }

        public TokenDTO(string token, long expiryTime, UserRole role)
            : base(token, expiryTime) {
            Role = role;
        }

        public override string ToString() {
            return $"{base.ToString()}, " +
                   $"{nameof(Role)}: {Role}";
        }

    }

}
