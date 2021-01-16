using System;
using System.Runtime.Serialization;

namespace EventoCore.Exceptions.Tickets {

    public class TicketAlreadyPurchased : Exception {

        /*------------------------ FIELDS REGION ------------------------*/

        /*------------------------ METHODS REGION ------------------------*/
        public TicketAlreadyPurchased() {
        }

        protected TicketAlreadyPurchased(SerializationInfo info, StreamingContext context)
            : base(info, context) {
        }

        public TicketAlreadyPurchased(string message)
            : base(message) {
        }

        public TicketAlreadyPurchased(string message, Exception innerException)
            : base(message, innerException) {
        }

    }

}
