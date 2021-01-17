using System;
using System.Runtime.Serialization;

namespace EventoCore.Exceptions.Users {

    public class EmailIsNullOrEmptyValueException : NullOrEmptyValueException {

        /*------------------------ FIELDS REGION ------------------------*/

        /*------------------------ METHODS REGION ------------------------*/
        public EmailIsNullOrEmptyValueException() {
        }

        public EmailIsNullOrEmptyValueException(SerializationInfo info, StreamingContext context)
            : base(info, context) {
        }

        public EmailIsNullOrEmptyValueException(string message)
            : base(message) {
        }

        public EmailIsNullOrEmptyValueException(string message, Exception innerException)
            : base(message, innerException) {
        }

    }

}
