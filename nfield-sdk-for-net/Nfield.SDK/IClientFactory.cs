using System;

namespace Nfield
{
    public interface IClientFactory
    {
        IClient Create(
            string domainName,
            string userName,
            string password);
    }
}
