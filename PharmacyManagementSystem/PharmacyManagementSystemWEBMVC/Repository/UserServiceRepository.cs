using System;
using System.Net.Http;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PharmacyManagementSystemWEBMVC.Repository
{
    public class UserServiceRepository
    {
        HttpClient client;
        public UserServiceRepository()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(ConfigurationManager.AppSettings["apiBaseURL"].ToString());
        }
        public HttpResponseMessage GetResponse(string url)
        {
            return client.GetAsync(url).Result;
        }
        public HttpResponseMessage PostResponse(string url, object content)
        {
            return client.PostAsJsonAsync(url, content).Result;
        }
        public HttpResponseMessage VerifyLogin(string url, object model)
        {
            return client.PostAsJsonAsync(url, model).Result;
        }
    }
}