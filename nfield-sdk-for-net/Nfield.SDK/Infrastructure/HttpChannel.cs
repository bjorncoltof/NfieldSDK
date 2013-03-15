using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Nfield.Infrastructure
{
    internal class HttpChannel : FactoryBase<HttpChannel, IHttpChannel>, IHttpChannel
    {
        private readonly HttpClient _httpClient;

        public HttpChannel()
        {
            _httpClient = new HttpClient();
        }

        public Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
        {
            return _httpClient.SendAsync(request);
        }
    }
}
