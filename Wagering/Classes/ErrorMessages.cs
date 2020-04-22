namespace Wagering
{
    public class ErrorMessages
    {
        public string Name { get; set; }
        public static string Unauthorized = "The user is not authorized.";

        public string AlreadySent
        {
            get
            {
                return $"The {Name} has already been sent.";
            }
        }

        public string NotCorresponding
        {
            get
            {
                return $"The {Name} does not correspond to this user.";
            }
        }

        public string NotFound
        {
            get
            {
                return $"The {Name} was not found.";
            }
        }
    }
}
