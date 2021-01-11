using EventoCore.Domain;

namespace EventoInfrastructure.Commands.Users {

    public class RegisterCommand : BaseCommand {

        /*------------------------ FIELDS REGION ------------------------*/
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }

        /*------------------------ METHODS REGION ------------------------*/

    }

}
