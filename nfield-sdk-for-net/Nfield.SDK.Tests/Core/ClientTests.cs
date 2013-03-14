using System.Net.Http;
using System.Threading.Tasks;
using Moq;
using Nfield.Core;
using Nfield.Infrastructure;
using Nfield.Models;
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
                var mockHttpClient = new Mock<IHttpClient>();
                var mockJsonConverter = new Mock<IJsonConverter>();
                var client = new Client(mockHttpClient.Object, mockJsonConverter.Object, "domain", "user", "password");

                Assert.Equal("domain", client.DomainName);
                Assert.Equal("user", client.UserName);
                Assert.Equal("password", client.Password);
            }
        }

        public class When_Authenticating
        {
            [Fact]
            public void Succesfull_Should_Not_Throw()
            {
                var expected = new AuthenticationResponse();

                var mockJsonConverter = new Mock<IJsonConverter>();
                mockJsonConverter
                    .Setup(c => c.Serialize(It.IsAny<AuthenticationRequest>()))
                    .Returns("request");
                mockJsonConverter
                    .Setup(c => c.Deserialize<AuthenticationResponse>(It.IsAny<string>()))
                    .Returns(expected);

                var mockHttpClient = new Mock<IHttpClient>();
                mockHttpClient
                    .Setup(mhc => mhc.SendAsync(It.IsAny<HttpRequestMessage>()))
                    .Returns(Task<HttpResponseMessage>.Factory.StartNew(() => new HttpResponseMessage { Content = new StringContent("response") }));

                var client = new Client(mockHttpClient.Object, mockJsonConverter.Object, "domain", "user", "password");

                var result = client.Authenticate();

                Assert.Same(expected, result);
            }
        }
    }
}
