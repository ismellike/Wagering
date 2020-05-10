using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Wagering.Models
{
    public class Wager : Group
    {
        public ICollection<WagerHostBid> Hosts { get; set; }
        public ICollection<WagerChallenge> Challenges { get; set; }

        [Column(TypeName = "decimal(18,7)")]
        public decimal? MinimumWager { get; set; }

        [Column(TypeName = "decimal(18,7)")]
        public decimal? MaximumWager { get; set; }
        public int ChallengeCount { get; set; }
        public IList<WagerRule> Rules { get; set; }

        public override bool IsApproved()
        {
            if (Status == 1)
                return true;

            foreach (WagerHostBid bid in Hosts)
                if (bid.Approved == null || bid.Approved == false)
                    return false;
            if (Hosts.Count == 0)
                return false;
            return true;
        }

        public override string GroupName
        {
            get
            {
                return GetGroupName.Wager(Id);
            }
        }
        public override IEnumerable<string> HostUsers()
        {
            return Hosts.Select(x => x.UserId);
        }

        public override IEnumerable<string> ClientUsers()
        {
            IEnumerable<string> result = Enumerable.Empty<string>();
            foreach (WagerChallenge challenge in Challenges)
            {
                result = result.Union(challenge.Challengers.Select(x => x.UserId));
            }
            return result.Distinct();
        }

        public override IEnumerable<string> AllUsers()
        {
            return HostUsers().Union(ClientUsers());
        }
    }
}