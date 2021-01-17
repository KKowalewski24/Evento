using System;
using System.Runtime.Serialization;

namespace EventoCore.Exceptions.Events {

    public class EventNameIsNullOrEmptyValueException : NullOrEmptyValueException {

        /*------------------------ FIELDS REGION ------------------------*/

        /*------------------------ METHODS REGION ------------------------*/
        public EventNameIsNullOrEmptyValueException() {
        }

        public EventNameIsNullOrEmptyValueException(SerializationInfo info, StreamingContext context)
            : base(info, context) {
        }

        public EventNameIsNullOrEmptyValueException(string message)
            : base(message) {
        }

        public EventNameIsNullOrEmptyValueException(string message, Exception innerException)
            : base(message, innerException) {
        }

    }

}
