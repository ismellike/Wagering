namespace Wagering.Models
{
    public enum Status
    {
        Created = 0,
        Confirmed = 1,
        Declined = 2,
        Canceled = 3
    }

    //Used for notifications
    public enum DataModel
    {
        None = 0,
        ApplicationUser = 10,
        Wager = 20,
        Tournament = 30,
    }
}
