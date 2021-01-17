using System;
using System.Runtime.Serialization;

namespace EventoCore.Exceptions.Events {

    public class StartDateEndDateWrongValueException : WrongValueException {

        /*------------------------ FIELDS REGION ------------------------*/

        /*------------------------ METHODS REGION ------------------------*/
        public StartDateEndDateWrongValueException() {
        }

        public StartDateEndDateWrongValueException(SerializationInfo info, StreamingContext context)
            : base(info, context) {
        }

        public StartDateEndDateWrongValueException(string message)
            : base(message) {
        }

        public StartDateEndDateWrongValueException(string message, Exception innerException)
            : base(message, innerException) {
        }

    }

}
