using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MvcServerSide
{
    public static class GlobalVariables
    {
        public static HttpClient Client = new HttpClient();

        static GlobalVariables()
        {
            Client.BaseAddress=new Uri("http://localhost:60283/api/");
            Client.DefaultRequestHeaders.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }
    }
}
