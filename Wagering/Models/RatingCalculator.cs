using System;

namespace Wagering.Models
{
    public static class RatingCalculator
    {
        public static decimal GetNewRating(this Rating r1, Rating r2, bool isWin)
        {
            return r1.Value + Constants.Rating.K * ((isWin ? 1 : 0) - GetExpectedOutcome(r1, r2));
        }

        public static decimal GetExpectedOutcome(Rating r1, Rating r2)
        {
            decimal x = r1.Value - r2.Value;
            return (decimal)(1 / (1 + Math.Pow(10, -1 * (double)(x / Constants.Rating.N))));
        }
    }
}
