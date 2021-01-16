using System;
using System.Runtime.Serialization;

namespace EventoCore.Exceptions.Tickets {

    public class TicketsOutOfAmountException : OutOfAmountException {

        /*------------------------ FIELDS REGION ------------------------*/

        /*------------------------ METHODS REGION ------------------------*/
        public TicketsOutOfAmountException() {
        }

        protected TicketsOutOfAmountException(SerializationInfo info, StreamingContext context)
            : base(info, context) {
        }

        public TicketsOutOfAmountException(string message)
            : base(message) {
        }

        public TicketsOutOfAmountException(string message, Exception innerException)
            : base(message, innerException) {
        }

    }

}

