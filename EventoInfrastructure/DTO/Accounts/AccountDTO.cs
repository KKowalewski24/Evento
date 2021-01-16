using EventoCore.Domain;

namespace EventoInfrastructure.DTO.Accounts {

    public class AccountDTO : BaseDTO {

        /*------------------------ FIELDS REGION ------------------------*/
        public string Name { get; set; }
        public string Email { get; set; }
        public UserRole Role { get; set; }

        /*------------------------ METHODS REGION ------------------------*/

    }

}
