using System.Collections.Generic;
using Wagering.Models;
using Xunit;

namespace Wagering.Tests
{
    public class WagerChallengeTests
    {
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(100)]
        public void WagerChallenge_IsApproved_ReturnTrue(int approvedCount)
        {
            //Arrange
            var wager = new WagerChallenge
            {
                Challengers = new List<WagerChallengeBid>()
            };
            for (int i = 0; i < approvedCount; i++)
                wager.Challengers.Add(new WagerChallengeBid { Approved = true });
            //Act
            var result = wager.IsApproved();
            //Assert
            Assert.True(result);
        }

        [Theory]
        [InlineData(new bool[] { })]
        [InlineData(new bool[] { false })]
        [InlineData(new bool[] { true, false })]
        [InlineData(new bool[] { false, false })]
        public void WagerChallenge_IsApproved_ReturnFalse(bool[] approved)
        {
            //Arrange
            var wager = new WagerChallenge
            {
                Challengers = new List<WagerChallengeBid>()
            };
            foreach (bool b in approved)
                wager.Challengers.Add(new WagerChallengeBid { Approved = b });
            //Act
            var result = wager.IsApproved();
            //Assert
            Assert.False(result);
        }
    }
}
