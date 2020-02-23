using System.ComponentModel.DataAnnotations.Schema;

namespace Wagering.Models
{
    //http://math.bu.edu/people/mg/ratings/rs/node1.html could be used for tournaments
    //https://blog.mackie.io/the-elo-algorithm
    public class Rating
    {
        public int Id { get; set; }

        public string GameName { get; set; }
        public Game Game { get; set; }
        public string UserDisplayName { get; set; }
        public Profile User { get; set; }

        [Column(TypeName = "decimal(9,2)")]
        public decimal Value { get; set; } = Constants.Rating.Initial;
        public int GamesPlayed { get; set; }
    }
}
