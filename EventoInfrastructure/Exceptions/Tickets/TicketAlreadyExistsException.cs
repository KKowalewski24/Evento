using System;
using System.Runtime.Serialization;

namespace EventoInfrastructure.Exceptions.Tickets {

    public class TicketAlreadyExistsException : AlreadyExistsException {

        /*------------------------ FIELDS REGION ------------------------*/

        /*------------------------ METHODS REGION ------------------------*/
        public TicketAlreadyExistsException() {
        }

        public TicketAlreadyExistsException(SerializationInfo info, StreamingContext context)
            : base(info, context) {
        }

        public TicketAlreadyExistsException(string message)
            : base(message) {
        }

        public TicketAlreadyExistsException(string message, Exception innerException)
            : base(message, innerException) {
        }

    }

}
