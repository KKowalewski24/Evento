using System;
using System.Runtime.Serialization;

namespace EventoCore.Exceptions {

    public abstract class NullOrEmptyValueException : Exception {

        /*------------------------ FIELDS REGION ------------------------*/

        /*------------------------ METHODS REGION ------------------------*/
        protected NullOrEmptyValueException() {
        }

        protected NullOrEmptyValueException(SerializationInfo info, StreamingContext context)
            : base(info, context) {
        }

        protected NullOrEmptyValueException(string message)
            : base(message) {
        }

        protected NullOrEmptyValueException(string message, Exception innerException)
            : base(message, innerException) {
        }

    }

}
