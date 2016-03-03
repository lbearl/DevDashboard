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
                public const string Servers = "api/Servers";
            }
        }
        /// <summary>
        /// Controller specific constants, these should be the names of the web controllers
        /// </summary>
        public static class Controller
        {
            public const string Dashboard = "Dashboard";

            public const string Home = "Home";

            public const string Servers = "Servers";

            public const string Account = "Account";

            /// <summary>
            /// Controller action constants, these should be the names of the actions within controllers
            /// </summary>
            public static class Actions
            {
                public const string Index = "Index";
                public const string Login = "Login";
                public const string Logoff = "Logoff";
                public const string Register = "Register";
                public const string Create = "Create";
                public const string Edit = "Edit";
                public const string Details = "Details";
                public const string Delete = "Delete";

                public static class ModelState
                {
                    public const string OldPassword = "OldPassword";
                }
            }

            public static class PartialViews
            {
                public const string LoginPartial = "_LoginPartial";
            }
        }

        /// <summary>
        /// Validation messages used to inform the user that they entered something incorrect
        /// </summary>
        public static class Validation
        {
            public const string InvalidUserNameOrPassword = "Invalid username or password.";
        }

        /// <summary>
        /// Has strings used in the test project
        /// </summary>
        public static class Test
        {
            public static class Trait
            {
                public static class TraitType
                {
                    public const string Category = "Category";
                }
                public static class TraitTypeValues
                {
                    public const string Controller = "Controller";
                }
            }
        }
    }
}
