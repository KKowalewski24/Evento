using System;
using System.Runtime.Serialization;

namespace EventoCore.Exceptions.Users {

    public class PasswordIsNullOrEmptyValueException : NullOrEmptyValueException {

        /*------------------------ FIELDS REGION ------------------------*/

        /*------------------------ METHODS REGION ------------------------*/
        public PasswordIsNullOrEmptyValueException() {
        }

        public PasswordIsNullOrEmptyValueException(SerializationInfo info, StreamingContext context)
            : base(info, context) {
        }

        public PasswordIsNullOrEmptyValueException(string message)
            : base(message) {
        }

        public PasswordIsNullOrEmptyValueException(string message, Exception innerException)
            : base(message, innerException) {
        }

    }

}
