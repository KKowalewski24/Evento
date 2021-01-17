using System;
using System.Runtime.Serialization;

namespace EventoCore.Exceptions {

    public class NotEnoughException : Exception {

        /*------------------------ FIELDS REGION ------------------------*/

        /*------------------------ METHODS REGION ------------------------*/
        public NotEnoughException() {
        }

        protected NotEnoughException(SerializationInfo info, StreamingContext context)
            : base(info, context) {
        }

        public NotEnoughException(string message)
            : base(message) {
        }

        public NotEnoughException(string message, Exception innerException)
            : base(message, innerException) {
        }

    }

}
