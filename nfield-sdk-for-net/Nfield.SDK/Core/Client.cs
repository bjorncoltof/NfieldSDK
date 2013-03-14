using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Nfield.Core
{
    internal class Client : IClient
    {
        internal HttpClient _httpClient;

        public Client(string domainName, string userName, string password)
        {
            DomainName = domainName;
            UserName = userName;
            Password = password;
        }

        public string DomainName { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }

        public Task ConnectAsync()
        {
            return Task.Factory.StartNew(() => { });
        }

        public void Dispose()
        {
        }
    }
}
