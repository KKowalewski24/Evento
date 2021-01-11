using System;
using System.Runtime.Serialization;

namespace EventoInfrastructure.Exceptions.Users {

    public class UserNotFoundException : NotFoundException {

        /*------------------------ FIELDS REGION ------------------------*/

        /*------------------------ METHODS REGION ------------------------*/
        public UserNotFoundException() {
        }

        public UserNotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context) {
        }

        public UserNotFoundException(string message)
            : base(message) {
        }

        public UserNotFoundException(string message, Exception innerException)
            : base(message, innerException) {
        }

    }

}
