namespace EventoApi.Constants {

    public static class Constants {

        /* Base Constants */
        public const string SLASH = "/";
        public const string CONTROLLER = "[controller]";
        public const string BASE_PATH = SLASH + CONTROLLER;

        /* Event Controller Constants */
        public const string BASE_PATH_EVENT_CONTROLLER = SLASH + EVENT_CONTROLLER_EVENT;
        public const string EVENT_CONTROLLER_EVENT = "event";
        public const string EVENT_CONTROLLER_PARAM_EVENT_ID = "{eventId}";

        /* Account Controller Constants */
        public const string BASE_PATH_ACCOUNT_CONTROLLER = SLASH + ACCOUNT_CONTROLLER_ACCOUNT;
        public const string ACCOUNT_CONTROLLER_ACCOUNT = "account";
        public const string ACCOUNT_CONTROLLER_TICKET = "ticket";
        public const string ACCOUNT_CONTROLLER_REGISTER = "register";
        public const string ACCOUNT_CONTROLLER_LOGIN = "login";

    }

}
