using System;
using EventoCore.Domain;
using EventoCore.Exceptions.Enums;

namespace EventoCore.Extensions {

    public static class DomainExtensions {

        /*------------------------ FIELDS REGION ------------------------*/

        /*------------------------ METHODS REGION ------------------------*/
        public static string FromEnumToString(this UserRole userRole) {
            return userRole.ToString();
        }

        public static UserRole FromStringToUserRole(this string stringForm) {
            if (ExtractEnumNameAndCheckEquality(UserRole.Admin, stringForm)) {
                return UserRole.Admin;
            } else if (ExtractEnumNameAndCheckEquality(UserRole.User, stringForm)) {
                return UserRole.User;
            }

            throw new EnumWrongValueException();
        }

        private static bool ExtractEnumNameAndCheckEquality(UserRole userRole, string stringValue) {
            return stringValue.ToLowerInvariant() ==
                   Enum.GetName(typeof(UserRole), userRole).ToLowerInvariant();
        }

    }

}
