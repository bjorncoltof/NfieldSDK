using System;
using System.Threading.Tasks;
using Nfield.Models;

namespace Nfield.Core
{
    public interface IClient : IDisposable
    {
        string DomainName { get; }
        string UserName { get; }
        string Password { get; }

        Task<AuthenticationResponse> AuthenticateAsync();
    }
}