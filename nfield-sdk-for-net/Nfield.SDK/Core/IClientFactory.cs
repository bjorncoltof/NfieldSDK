using System;

namespace Nfield.Core
{
    public interface IClientFactory
    {
        IClient Create(
            string domainName,
            string userName,
            string password);
    }
}
