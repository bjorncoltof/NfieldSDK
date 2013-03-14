using System;
using Nfield.Infrastructure;

namespace Nfield.Core
{
    public class ClientFactory : IClientFactory
    {
        #region Implementation of IClientFactory

        public IClient Create(string domainName, string userName, string password)
        {
            return new Client(new HttpClientWrapper(), new JsonConverter(), domainName, userName, password);
        }

        #endregion
    }
}
