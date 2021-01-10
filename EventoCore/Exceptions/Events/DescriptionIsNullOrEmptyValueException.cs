using System;
using System.Runtime.Serialization;

namespace EventoCore.Exceptions.Events {

    public class DescriptionIsNullOrEmptyValueException : NullOrEmptyValueException {

        /*------------------------ FIELDS REGION ------------------------*/

        /*------------------------ METHODS REGION ------------------------*/
        public DescriptionIsNullOrEmptyValueException() {
        }

        public DescriptionIsNullOrEmptyValueException(SerializationInfo info, StreamingContext context)
            : base(info, context) {
        }

        public DescriptionIsNullOrEmptyValueException(string message)
            : base(message) {
        }

        public DescriptionIsNullOrEmptyValueException(string message, Exception innerException)
            : base(message, innerException) {
        }

    }

}
