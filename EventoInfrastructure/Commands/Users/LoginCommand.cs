namespace EventoInfrastructure.Commands.Users {

    public class LoginCommand {

        /*------------------------ FIELDS REGION ------------------------*/
        public string Email { get; set; }
        public string Password { get; set; }

        /*------------------------ METHODS REGION ------------------------*/
        public LoginCommand() {
        }

        public LoginCommand(string email, string password) {
            Email = email;
            Password = password;
        }

        public override string ToString() {
            return $"{base.ToString()}, " +
                   $"{nameof(Email)}: {Email}, " +
                   $"{nameof(Password)}: {Password}";
        }

    }

}
