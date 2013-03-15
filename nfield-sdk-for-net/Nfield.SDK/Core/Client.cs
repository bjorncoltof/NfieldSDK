using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Nfield.Infrastructure;
using Nfield.Models;

namespace Nfield.Core
{
    internal class Client : IClient
    {
        public Client(
            IHttpChannel httpClient,
            string domainName,
            string userName,
            string password
            )
        {
            HttpClient = httpClient;
            DomainName = domainName;
            UserName = userName;
            Password = password;
        }

        public IHttpChannel HttpClient { get; private set; }
        public string DomainName { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }

        public AuthenticationResponse Authenticate()
        {
            var converter = JsonConverter.Create();

            using (var requestMessage = new HttpRequestMessage(HttpMethod.Post, "http://manager.nfieldbeta.com/api/signin"))
            {
                var signInrequest = new AuthenticationRequest
                {
                    Domain = DomainName,
                    Name = UserName,
                    Password = Password
                };

                requestMessage.Content = new StringContent(converter.Serialize(signInrequest), Encoding.UTF8, "application/json");
                return HttpClient.SendAsync(requestMessage)
                    .ContinueWith( t => t.Result.Content.ReadAsStringAsync())
                    .Unwrap()
                    .ContinueWith(t => converter.Deserialize<AuthenticationResponse>(t.Result))
                    .Result;
            }
        }

        public void Dispose()
        {
        }
    }
}
