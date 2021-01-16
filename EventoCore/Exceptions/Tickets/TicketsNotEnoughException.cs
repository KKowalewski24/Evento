using System;
using System.Runtime.Serialization;

namespace EventoCore.Exceptions.Tickets {

    public class TicketsNotEnoughException : NotEnoughException {

        /*------------------------ FIELDS REGION ------------------------*/

        /*------------------------ METHODS REGION ------------------------*/
        public TicketsNotEnoughException() {
        }

        protected TicketsNotEnoughException(SerializationInfo info, StreamingContext context)
            : base(info, context) {
        }

        public TicketsNotEnoughException(string message)
            : base(message) {
        }

        public TicketsNotEnoughException(string message, Exception innerException)
            : base(message, innerException) {
        }

    }

}
