using System.Collections.Generic;

namespace EventoApi.Constants {

    public static class Constants {

        /* Base Constants */
        public const string SLASH = "/";
        public const string CONTROLLER = "[controller]";
        public const string BASE_PATH = SLASH + CONTROLLER;

        /* Event Controller Constants */
        public const string EVENT_CONTROLLER_EVENT = "event";
        public const string EVENT_CONTROLLER_PARAM_EVENT_ID = "{eventId}";
        public const string BASE_PATH_EVENT_CONTROLLER = SLASH + EVENT_CONTROLLER_EVENT;

        /* Account Controller Constants */
        public const string ACCOUNT_CONTROLLER_ACCOUNT = "account";
        public const string ACCOUNT_CONTROLLER_TICKET = "ticket";
        public const string ACCOUNT_CONTROLLER_REGISTER = "register";
        public const string ACCOUNT_CONTROLLER_LOGIN = "login";
        public const string BASE_PATH_ACCOUNT_CONTROLLER = SLASH + ACCOUNT_CONTROLLER_ACCOUNT;

        public static IEnumerable<string> Endpoints => _endpoints;

        private static readonly IList<string> _endpoints = new List<string> {
            BASE_PATH_EVENT_CONTROLLER,
            BASE_PATH_EVENT_CONTROLLER + EVENT_CONTROLLER_PARAM_EVENT_ID,
            BASE_PATH_ACCOUNT_CONTROLLER,
            BASE_PATH_ACCOUNT_CONTROLLER + ACCOUNT_CONTROLLER_TICKET,
            BASE_PATH_ACCOUNT_CONTROLLER + ACCOUNT_CONTROLLER_REGISTER,
            BASE_PATH_ACCOUNT_CONTROLLER + ACCOUNT_CONTROLLER_LOGIN
        };

    }

}
