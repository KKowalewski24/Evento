using System;
using System.Runtime.Serialization;

namespace EventoCore.Exceptions.Tickets {

    public class TicketNotPurchased : Exception {

        /*------------------------ FIELDS REGION ------------------------*/

        /*------------------------ METHODS REGION ------------------------*/
        public TicketNotPurchased() {
        }

        protected TicketNotPurchased(SerializationInfo info, StreamingContext context)
            : base(info, context) {
        }

        public TicketNotPurchased(string message)
            : base(message) {
        }

        public TicketNotPurchased(string message, Exception innerException)
            : base(message, innerException) {
        }

    }

}
