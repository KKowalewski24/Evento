﻿using System;

namespace EventoInfrastructure.Commands.Users {

    public class RegisterCommand : BaseCommand {

        /*------------------------ FIELDS REGION ------------------------*/
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        /*------------------------ METHODS REGION ------------------------*/
        public RegisterCommand() {
        }

        public RegisterCommand(Guid id, string name, string email, string password, string role)
            : base(id) {
            Name = name;
            Email = email;
            Password = password;
            Role = role;
        }

        public override string ToString() {
            return $"{base.ToString()}, " +
                   $"{nameof(Name)}: {Name}, " +
                   $"{nameof(Email)}: {Email}, " +
                   $"{nameof(Password)}: {Password}, " +
                   $"{nameof(Role)}: {Role}";
        }

    }

}
