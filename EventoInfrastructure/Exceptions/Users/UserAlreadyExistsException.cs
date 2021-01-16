using System;
using System.Runtime.Serialization;

namespace EventoInfrastructure.Exceptions.Users {

    public class UserAlreadyExistsException : AlreadyExistsException {

        /*------------------------ FIELDS REGION ------------------------*/

        /*------------------------ METHODS REGION ------------------------*/
        public UserAlreadyExistsException() {
        }

        public UserAlreadyExistsException(SerializationInfo info, StreamingContext context)
            : base(info, context) {
        }

        public UserAlreadyExistsException(string message)
            : base(message) {
        }

        public UserAlreadyExistsException(string message, Exception innerException)
            : base(message, innerException) {
        }

    }

}
