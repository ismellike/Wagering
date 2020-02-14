using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using stellar_dotnet_sdk;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Wagering.Data;
using Wagering.Server.Controllers;
using Xunit;

namespace Wagering.Tests
{
    public class StellarControllerTests : IClassFixture<DataFixture>
    {
        private readonly DataFixture Fixture;
        private readonly HttpContext DefaultContext;
        private const string username = "user0";

        public StellarControllerTests(DataFixture fixture)
        {
            Fixture = fixture;
            DefaultContext = new DefaultHttpContext
            {
                User = new ClaimsPrincipal(new GenericIdentity(username))
            };
        }

        /// <summary>
        /// For Test Accounts
        /// </summary>
        /// <returns></returns>
        //[Fact]
        public async Task Create_ReturnsKeys()
        {
            //Arrange
            DbContextOptions<ApplicationDbContext> options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("Create_ReturnsKeys").Options;
            var controller = new StellarController(Fixture.Context)
            {
                ControllerContext = new ControllerContext
                {
                    HttpContext = DefaultContext
                }
            };

            //Act
            var result = await controller.CreateAccount();

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsType<KeyPair>(okResult.Value);
            //Ensure public key is set
            KeyPair pair = okResult.Value as KeyPair;
            Assert.Equal(pair.AccountId, Fixture.Context.Users.First(x => x.UserName == username).Profile.PublicKey);
        }
    }
}
