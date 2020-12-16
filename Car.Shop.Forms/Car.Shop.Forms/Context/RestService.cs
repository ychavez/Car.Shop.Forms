
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Car.Shop.Forms.Context
{
    public class RestService
    {
        private HttpClient _client;
        private Uri _UrlBase;

        public RestService()
        {
            _UrlBase = new Uri("https://productsapidw.azurewebsites.net/");
            _client = new HttpClient();
            _client.BaseAddress = _UrlBase;
        }

        ///public List<>

    }
}
