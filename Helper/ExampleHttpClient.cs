using System;
using System.Net.Http;

namespace HttpClientFactoryExample.Helper
{
    public class ExampleHttpClient
    {
        public HttpClient Client { get; private set; }

        public ExampleHttpClient(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri("http://www.osmankurt.net/");
            httpClient.DefaultRequestHeaders.Add("ExampleHeaderKey", "for-example-three");
            Client = httpClient;
        }
    }
}
