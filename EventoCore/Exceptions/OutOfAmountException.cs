using System;
using System.Runtime.Serialization;

namespace EventoCore.Exceptions {

    public class OutOfAmountException : Exception {

        /*------------------------ FIELDS REGION ------------------------*/

        /*------------------------ METHODS REGION ------------------------*/
        public OutOfAmountException() {
        }

        protected OutOfAmountException(SerializationInfo info, StreamingContext context)
            : base(info, context) {
        }

        public OutOfAmountException(string message)
            : base(message) {
        }

        public OutOfAmountException(string message, Exception innerException)
            : base(message, innerException) {
        }

    }

}
