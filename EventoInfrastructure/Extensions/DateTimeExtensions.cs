using System;

namespace EventoInfrastructure.Extensions {

    public static class DateTimeExtensions {

        /*------------------------ FIELDS REGION ------------------------*/

        /*------------------------ METHODS REGION ------------------------*/
        public static long ToTimestamp(this DateTime dateTime) {
            DateTime epoch = new DateTime(
                1970, 1, 1, 0, 0, 0, DateTimeKind.Utc
            );

            DateTime time = dateTime.Subtract(new TimeSpan(epoch.Ticks));

            return time.Ticks / 10000;
        }

    }

}
