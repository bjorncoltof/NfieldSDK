using Nfield.Core;
using Xunit;

namespace Tests.Nfield.Core
{
    public class ClientFactoryTests
    {
        public class When_Creating_A_Client
        {
            [Fact]
            public void Returns_Correct_Client()
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
}
