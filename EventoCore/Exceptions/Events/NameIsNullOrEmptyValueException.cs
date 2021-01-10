using System;
using System.Runtime.Serialization;

namespace EventoCore.Exceptions.Events {

    public class NameIsNullOrEmptyValueException : NullOrEmptyValueException {

        /*------------------------ FIELDS REGION ------------------------*/

        /*------------------------ METHODS REGION ------------------------*/
        public NameIsNullOrEmptyValueException() {
        }

        public NameIsNullOrEmptyValueException(SerializationInfo info, StreamingContext context)
            : base(info, context) {
        }

        public NameIsNullOrEmptyValueException(string message)
            : base(message) {
        }

        public NameIsNullOrEmptyValueException(string message, Exception innerException)
            : base(message, innerException) {
        }

    }

}
