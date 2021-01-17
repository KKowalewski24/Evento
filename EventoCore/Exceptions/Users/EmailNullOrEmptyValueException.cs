using System;
using System.Runtime.Serialization;

namespace EventoCore.Exceptions.Users {

    public class EmailNullOrEmptyValueException : NullOrEmptyValueException {

        /*------------------------ FIELDS REGION ------------------------*/

        /*------------------------ METHODS REGION ------------------------*/
        public EmailNullOrEmptyValueException() {
        }

        public EmailNullOrEmptyValueException(SerializationInfo info, StreamingContext context)
            : base(info, context) {
        }

        public EmailNullOrEmptyValueException(string message)
            : base(message) {
        }

        public EmailNullOrEmptyValueException(string message, Exception innerException)
            : base(message, innerException) {
        }

    }

}
