using Wagering.Models;
using Xunit;

namespace Wagering.Tests
{
    public class RatingCalculatorTests
    {
        [Theory]
        [InlineData(Constants.Rating.Initial / 2, Constants.Rating.Initial)]
        [InlineData(Constants.Rating.Initial, Constants.Rating.Initial)]
        [InlineData(Constants.Rating.Initial * 2, Constants.Rating.Initial)]
        public void RatingCalculator_WinnerRatingIncreases(int winRating, int loseRating)
        {
            //setup
            var winner = new Rating { Value = winRating };
            var loser = new Rating { Value = loseRating };
            //execute
            var result = winner.GetNewRating(loser, true);
            //assert
            Assert.True(result > winner.Value);
        }

        [Theory]
        [InlineData(Constants.Rating.Initial / 2, Constants.Rating.Initial)]
        [InlineData(Constants.Rating.Initial, Constants.Rating.Initial)]
        [InlineData(Constants.Rating.Initial * 2, Constants.Rating.Initial)]
        public void RatingCalculator_LoserRatingDecreases(int winRating, int loseRating)
        {
            //setup
            var winner = new Rating { Value = winRating };
            var loser = new Rating { Value = loseRating };
            //execute
            var result = loser.GetNewRating(winner, false);
            //assert
            Assert.True(result < loser.Value);
        }
    }
}
