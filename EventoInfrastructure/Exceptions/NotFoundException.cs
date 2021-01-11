using System;
using System.Runtime.Serialization;

namespace EventoInfrastructure.Exceptions {

    public abstract class NotFoundException : Exception {

        /*------------------------ FIELDS REGION ------------------------*/

        /*------------------------ METHODS REGION ------------------------*/
        protected NotFoundException() {
        }

        protected NotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context) {
        }

        protected NotFoundException(string message)
            : base(message) {
        }

        protected NotFoundException(string message, Exception innerException)
            : base(message, innerException) {
        }

    }

}
