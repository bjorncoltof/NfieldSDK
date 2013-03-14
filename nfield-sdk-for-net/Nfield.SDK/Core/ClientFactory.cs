using System;

namespace Nfield.Core
{
    public class ClientFactory : IClientFactory
    {
        #region Implementation of IClientFactory

        public IClient Create(string domainName, string userName, string password)
        {
            return new Client(domainName, userName, password);
        }

        #endregion
    }
}
