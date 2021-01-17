using System;
using System.Runtime.Serialization;

namespace EventoInfrastructure.Exceptions.Tickets {

    public class TicketNotFoundException : NotFoundException {

        /*------------------------ FIELDS REGION ------------------------*/

        /*------------------------ METHODS REGION ------------------------*/
        public TicketNotFoundException() {
        }

        public TicketNotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context) {
        }

        public TicketNotFoundException(string message)
            : base(message) {
        }

        public TicketNotFoundException(string message, Exception innerException)
            : base(message, innerException) {
        }

    }

}
