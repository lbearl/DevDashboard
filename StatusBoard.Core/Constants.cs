namespace StatusBoard.Core
{
    /// <summary>
    /// Constants contains a number of inner classes defining string constants for areas of the system
    /// Note that all strings which will not be modified at runtime are being stored as "const" in order
    /// to possibly make things slightly faster (but probably not by much)
    /// </summary>
    public static class Constants
    {
        public static class ApiController
        {
            public static class Routes
            {
                public const string GetAllServers = "api/ServerActions/GetAllServers";
            }
        }
        /// <summary>
        /// Controller specific constants, these should be the names of the web controllers
        /// </summary>
        public static class Controller
        {
            public const string Dashboard = "Dashboard";

            /// <summary>
            /// Controller action constants, these should be the names of the actions within controllers
            /// </summary>
            public static class Actions
            {
                public const string Index = "Index";
                public const string Manage = "Manage";

                public static class ModelState
                {
                    public const string OldPassword = "OldPassword";
                }
            }
        }

        /// <summary>
        /// Validation messages used to inform the user that they entered something incorrect
        /// </summary>
        public static class Validation
        {
            public const string InvalidUserNameOrPassword = "Invalid username or password.";
        }
    }
}
