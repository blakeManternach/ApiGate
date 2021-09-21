using ApiGate;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Tests.IntegrationTests.Controllers
{
    class ControllerIntegrationTest
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public ControllerIntegrationTest()
        {
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            _client = _server.CreateClient();
        }
        
        // TODO: Controller Integration Tests
    }
}
