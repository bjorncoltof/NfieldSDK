using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Nfield.Infrastructure;
using Nfield.Models;

namespace Nfield.Core
{
    internal class Client : IClient
    {
        private readonly IJsonConverter _jsonConverter;

        public Client(
            IHttpClient httpClient,
            IJsonConverter jsonConverter,
            string domainName,
            string userName,
            string password
            )
        {
            _jsonConverter = jsonConverter;

            HttpClient = httpClient;
            DomainName = domainName;
            UserName = userName;
            Password = password;
        }

        public IHttpClient HttpClient { get; private set; }
        public string DomainName { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }

        public AuthenticationResponse Authenticate()
        {
            using (var requestMessage = new HttpRequestMessage(HttpMethod.Post, "http://manager.nfieldbeta.com/api/signin"))
            {
                var signInrequest = new AuthenticationRequest
                {
                    Domain = DomainName,
                    Name = UserName,
                    Password = Password
                };

                requestMessage.Content = new StringContent(_jsonConverter.Serialize(signInrequest), Encoding.UTF8, "application/json");
                return HttpClient.SendAsync(requestMessage)
                    .ContinueWith( t => t.Result.Content.ReadAsStringAsync())
                    .Unwrap()
                    .ContinueWith(t => _jsonConverter.Deserialize<AuthenticationResponse>(t.Result))
                    .Result;
            }
        }

        public void Dispose()
        {
        }
    }
}
