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
        [Fact]
        public void Client_Constructor_Returns_Correct_Client()
        {
            var mockHttpClient = new Mock<IHttpChannel>();
            var client = new Client(mockHttpClient.Object, "domain", "user", "password");

            Assert.Equal("domain", client.DomainName);
            Assert.Equal("user", client.UserName);
            Assert.Equal("password", client.Password);
        }

        [Fact]
        public void Client_Authenticate_Returns_Correct_Response()
        {
            var expected = new AuthenticationResponse();

            var mockJsonConverter = new Mock<IJsonConverter>();
            mockJsonConverter
                .Setup(c => c.Serialize(It.IsAny<AuthenticationRequest>()))
                .Returns("request");
            mockJsonConverter
                .Setup(c => c.Deserialize<AuthenticationResponse>(It.IsAny<string>()))
                .Returns(expected);
            JsonConverter.Initialize(() => mockJsonConverter.Object);

            var mockHttpClient = new Mock<IHttpChannel>();
            mockHttpClient
                .Setup(mhc => mhc.SendAsync(It.IsAny<HttpRequestMessage>()))
                .Returns(Task<HttpResponseMessage>.Factory.StartNew(() => new HttpResponseMessage { Content = new StringContent("response") }));

            var client = new Client(mockHttpClient.Object, "domain", "user", "password");

            var result = client.AuthenticateAsync();

            Assert.Same(expected, result.Result);
        }
    }
}
