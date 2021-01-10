using System;
using System.Runtime.Serialization;

namespace EventoInfrastructure.Exceptions.Events {

    public class EventAlreadyExistsException : AlreadyExistsException{

        /*------------------------ FIELDS REGION ------------------------*/

        /*------------------------ METHODS REGION ------------------------*/
        public EventAlreadyExistsException() {
        }

        public EventAlreadyExistsException(SerializationInfo info, StreamingContext context)
            : base(info, context) {
        }

        public EventAlreadyExistsException(string message)
            : base(message) {
        }

        public EventAlreadyExistsException(string message, Exception innerException)
            : base(message, innerException) {
        }

    }

}

