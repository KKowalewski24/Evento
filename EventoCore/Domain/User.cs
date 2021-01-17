using System;
using EventoCore.Exceptions.Users;
using EventoCore.Security;

namespace EventoCore.Domain {

    public class User : BaseEntity {

        /*------------------------ FIELDS REGION ------------------------*/
        private string _password;
        private string _name;
        private string _email;

        public string Name {
            get => _name;
            set {
                if (string.IsNullOrWhiteSpace(value)) {
                    throw new UserNameIsNullOrEmptyValueException();
                }

                _name = value;
            }
        }

        public string Email {
            get => _email;
            set {
                if (string.IsNullOrWhiteSpace(value)) {
                    throw new EmailIsNullOrEmptyValueException();
                }

                _email = value;
            }
        }

        public string Password {
            get => _password;
            set {
                if (string.IsNullOrWhiteSpace(value)) {
                    throw new PasswordIsNullOrEmptyValueException();
                }

                _password = new HashingProvider().ComputeHashFromStringToString(value);
            }
        }

        public UserRole Role { get; private set; }
        public DateTime CreateDate { get; private set; }

        /*------------------------ METHODS REGION ------------------------*/
        protected User() {
        }

        public User(Guid id, string name, string email, string password, UserRole role)
            : base(id) {
            Name = name;
            Email = email;
            Password = password;
            Role = role;
            CreateDate = DateTime.UtcNow;
        }

        protected bool Equals(User other) {
            return base.Equals(other) && Name == other.Name && Email == other.Email &&
                   Password == other.Password && Role == other.Role &&
                   CreateDate.Equals(other.CreateDate);
        }

        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj)) {
                return false;
            }

            if (ReferenceEquals(this, obj)) {
                return true;
            }

            if (obj.GetType() != this.GetType()) {
                return false;
            }

            return Equals((User)obj);
        }

        public override int GetHashCode() {
            unchecked {
                int hashCode = base.GetHashCode();
                hashCode = (hashCode * 397) ^ (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Email != null ? Email.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Password != null ? Password.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (int)Role;
                hashCode = (hashCode * 397) ^ CreateDate.GetHashCode();
                return hashCode;
            }
        }

        public override string ToString() {
            return $"{base.ToString()}, " +
                   $"{nameof(Name)}: {Name}, " +
                   $"{nameof(Email)}: {Email}, " +
                   $"{nameof(Password)}: {Password}, " +
                   $"{nameof(Role)}: {Role}, " +
                   $"{nameof(CreateDate)}: {CreateDate}";
        }

    }

}
