using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using HttpClientFactoryExample.Helper;
using Microsoft.AspNetCore.Mvc;

namespace HttpClientFactoryExample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ExampleHttpClient _exampleHttpClient;

        public HomeController(IHttpClientFactory httpClientFactory, ExampleHttpClient exampleHttpClient)
        {
            _httpClientFactory = httpClientFactory;
            _exampleHttpClient = exampleHttpClient;
        }

        [HttpGet]
        [Route("exampleone")]
        public async Task<string> ExampleOne()
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("http://www.osmankurt.net");
            var result = await client.GetStringAsync("/");
            return result;
        }

        [HttpGet]
        [Route("exampletwo")]
        public async Task<string> ExampleTwo()
        {
            var client = _httpClientFactory.CreateClient("osmankurt");
            client.BaseAddress = new Uri("http://www.osmankurt.net");
            var result = await client.GetStringAsync("/");
            return result;
        }

        [HttpGet]
        [Route("examplethree")]
        public async Task<string> ExampleThree()
        {
            var result = await _exampleHttpClient.Client.GetStringAsync("/");
            return result;
        }
    }
}
