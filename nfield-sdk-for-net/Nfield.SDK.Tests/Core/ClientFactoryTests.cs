using Nfield.Core;
using Xunit;

namespace Tests.Nfield.Core
{
    public class ClientFactoryTests
    {
        [Fact]
        public void ClientFactory_Create_Returns_Correct_Client()
        {
            var clientFactory = new ClientFactory();

            var result = clientFactory.Create("domain", "user", "password");

            Assert.NotNull(result);
            Assert.Equal("domain", result.DomainName);
            Assert.Equal("user", result.UserName);
            Assert.Equal("password", result.Password);
        }
    }
}
