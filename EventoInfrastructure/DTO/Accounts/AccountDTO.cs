using System;
using EventoCore.Domain;

namespace EventoInfrastructure.DTO.Accounts {

    public class AccountDTO : BaseDTO {

        /*------------------------ FIELDS REGION ------------------------*/
        public string Name { get; set; }
        public string Email { get; set; }
        public UserRole Role { get; set; }

        /*------------------------ METHODS REGION ------------------------*/
        public AccountDTO() {
        }

        public AccountDTO(Guid id, string name, string email, UserRole role)
            : base(id) {
            Name = name;
            Email = email;
            Role = role;
        }

        public override string ToString() {
            return $"{base.ToString()}, " +
                   $"{nameof(Name)}: {Name}, " +
                   $"{nameof(Email)}: {Email}, " +
                   $"{nameof(Role)}: {Role}";
        }

    }

}
