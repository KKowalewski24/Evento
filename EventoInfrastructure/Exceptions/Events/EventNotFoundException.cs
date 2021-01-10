using System;
using System.Runtime.Serialization;

namespace EventoInfrastructure.Exceptions.Events {

    public class EventNotFoundException : NotFoundException {

        /*------------------------ FIELDS REGION ------------------------*/

        /*------------------------ METHODS REGION ------------------------*/
        public EventNotFoundException() {
        }

        public EventNotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context) {
        }

        public EventNotFoundException(string message)
            : base(message) {
        }

        public EventNotFoundException(string message, Exception innerException)
            : base(message, innerException) {
        }

    }

}
