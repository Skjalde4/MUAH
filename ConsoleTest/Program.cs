using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using WebServer;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {

            const string ServerUrl = "HTTP://localhost:58058";
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                try
                {
                    var response = client.GetAsync("api/Customers").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var customers = response.Content.ReadAsAsync<IEnumerable<Customer>().Result;
                    }
                    //Customer customer1 = new Customer() {Id = 1, Name = "Helena Skjaldgaard", Password = "skjalde4", PhoneNo = "23493388"};
                    // var post = client.PostAsJsonAsync("Api/Customers", customer1).Result;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
    }
}
