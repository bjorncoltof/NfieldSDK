﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Nfield.Infrastructure
{
    public interface IHttpChannel
    {
        Task<HttpResponseMessage> SendAsync(HttpRequestMessage request);
    }
}
