using Xunit;

namespace Wagering.Tests
{
    public class WagerControllerTests : IClassFixture<DataFixture>
    {
        private readonly DataFixture Fixture;

        public WagerControllerTests(DataFixture fixture)
        {
            Fixture = fixture;
        }
    }
}
