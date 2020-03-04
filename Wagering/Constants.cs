namespace Wagering
{
    public static class Constants
    {
        public static string[] Platforms = new string[] { "Playstation", "Xbox", "PC", "Nintendo", "Mobile" };
        public static string[] Inputs = new string[] { "Controller", "Mouse and Keyboard", "Touchscreen" };
        public struct Rating
        {
            public const int Initial = 1000;
            public const int K = 750;
            public const int N = 1000;
        }
        public const string NameRegex = @"^[a-zA-Z0-9-_]+$";
    }
}
