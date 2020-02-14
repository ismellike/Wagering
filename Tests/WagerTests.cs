using System.Collections.Generic;
using Wagering.Models;
using Xunit;

namespace Wagering.Tests
{
    public class WagerTests
    {
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(100)]
        public void Wager_IsApproved_ReturnTrue(int approvedCount)
        {
            //Arrange
            var wager = new Wager
            {
                Hosts = new List<WagerHostBid>()
            };
            for (int i = 0; i < approvedCount; i++)
                wager.Hosts.Add(new WagerHostBid { Approved = true });
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
        public void Wager_IsApproved_ReturnFalse(bool[] approved)
        {
            //Arrange
            var wager = new Wager
            {
                Hosts = new List<WagerHostBid>()
            };
            foreach (bool b in approved)
                wager.Hosts.Add(new WagerHostBid { Approved = b });
            //Act
            var result = wager.IsApproved();
            //Assert
            Assert.False(result);
        }
    }
}
