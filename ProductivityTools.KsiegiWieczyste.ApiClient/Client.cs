using ProductivityTools.SimpleHttpPostClient;
using System;

namespace ProductivityTools.KsiegiWieczyste.ApiClient
{
    public class Client
    {
        HttpPostClient httpClient;

        public Client()
        {
            httpClient = new HttpPostClient();
            httpClient.SetBaseUrl("http://localhost:1337/Api/");
        }

        public void Sent(Model.Ksiega ksiega)
        {
            var result1 = httpClient.PostAsync<Model.Ksiega>("kw", "", ksiega);
        }
    }
}
