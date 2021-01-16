using System;
using System.Runtime.Serialization;

namespace EventoCore.Exceptions {

    public abstract class WrongValueException : Exception {

        /*------------------------ FIELDS REGION ------------------------*/

        /*------------------------ METHODS REGION ------------------------*/
        protected WrongValueException() {
        }

        protected WrongValueException(SerializationInfo info, StreamingContext context)
            : base(info, context) {
        }

        protected WrongValueException(string message)
            : base(message) {
        }

        protected WrongValueException(string message, Exception innerException)
            : base(message, innerException) {
        }

    }

}
