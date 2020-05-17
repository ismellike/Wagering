namespace Wagering
{
    public static class Constants
    {
        public struct Rating
        {
            public const int Initial = 1000;
            public const int K = 750;
            public const int N = 1000;
        }
        public struct Claims
        {
            public const string DisplayName = "display_name";
            public const string IsVerified = "is_verified";
            public const string PublicKey = "public_key";
        }
        public const string NameRegex = @"^[a-zA-Z0-9]+$";
    }
}
