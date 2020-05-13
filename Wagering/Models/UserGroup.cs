#nullable disable
namespace Wagering.Models
{
    public class UserGroup
    {
        public int Id { get; set; }
        public string ProfileId { get; set; } = string.Empty;
        public Profile Profile { get; set; }
        public int? WagerId { get; set; }
        public Wager Wager { get; set; }
        public int? TournamentId { get; set; }
        public Tournament Tournament { get; set; }

        public string GroupName
        {
            get
            {
                if (WagerId.HasValue)
                    return GetGroupName.Wager(WagerId.Value);
                if (TournamentId.HasValue)
                    return GetGroupName.Tournament(TournamentId.Value);
                return null;
            }
        }

        public DataModel Type
        {
            get
            {
                if (WagerId.HasValue)
                    return DataModel.Wager;
                if (TournamentId.HasValue)
                    return DataModel.Tournament;
                return 0;
            }
        }
    }
}