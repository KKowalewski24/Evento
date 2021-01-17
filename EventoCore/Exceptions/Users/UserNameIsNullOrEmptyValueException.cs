using System;
using System.Runtime.Serialization;

namespace EventoCore.Exceptions.Users {

    public class UserNameIsNullOrEmptyValueException : NullOrEmptyValueException {

        /*------------------------ FIELDS REGION ------------------------*/

        /*------------------------ METHODS REGION ------------------------*/
        public UserNameIsNullOrEmptyValueException() {
        }

        public UserNameIsNullOrEmptyValueException(SerializationInfo info, StreamingContext context)
            : base(info, context) {
        }

        public UserNameIsNullOrEmptyValueException(string message)
            : base(message) {
        }

        public UserNameIsNullOrEmptyValueException(string message, Exception innerException)
            : base(message, innerException) {
        }

    }

}
