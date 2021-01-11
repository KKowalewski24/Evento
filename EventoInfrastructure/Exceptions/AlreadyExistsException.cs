using System;
using System.Runtime.Serialization;

namespace EventoInfrastructure.Exceptions {

    public abstract class AlreadyExistsException : Exception {

        /*------------------------ FIELDS REGION ------------------------*/

        /*------------------------ METHODS REGION ------------------------*/
        protected AlreadyExistsException() {
        }

        protected AlreadyExistsException(SerializationInfo info, StreamingContext context)
            : base(info, context) {
        }

        protected AlreadyExistsException(string message)
            : base(message) {
        }

        protected AlreadyExistsException(string message, Exception innerException)
            : base(message, innerException) {
        }

    }

}
