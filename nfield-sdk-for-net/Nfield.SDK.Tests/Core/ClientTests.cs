using Nfield.Core;
using Xunit;

namespace Tests.Nfield.Core
{
    public class ClientTests
    {
        public class When_Creating_A_Client
        {
            [Fact]
            public void Properties_Are_Set_Correctly()
            {
                var client = new Client("domain", "user", "password");

                Assert.Equal("domain", client.DomainName);
                Assert.Equal("user", client.UserName);
                Assert.Equal("password", client.Password);
            }
        }

        public class When_Connecting_Async
        {
            [Fact]
            public void Succesfull_Should_Not_Throw()
            {
                var client = new Client("domain", "user", "password");

                client.ConnectAsync().Wait();
            }
        }
    }
}
