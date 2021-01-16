using System;
using System.Runtime.Serialization;

namespace EventoCore.Exceptions.Enums {

    public class EnumWrongValueException : WrongValueException {

        /*------------------------ FIELDS REGION ------------------------*/

        /*------------------------ METHODS REGION ------------------------*/
        public EnumWrongValueException() {
        }

        public EnumWrongValueException(SerializationInfo info, StreamingContext context)
            : base(info, context) {
        }

        public EnumWrongValueException(string message)
            : base(message) {
        }

        public EnumWrongValueException(string message, Exception innerException)
            : base(message, innerException) {
        }

    }

}
