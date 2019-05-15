using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using MUAHWebServer;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {

            const string ServerUrl = "HTTP://muahcloudserver.database.windows.net";
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                try
                {
                    //Dette er post metoden
                    Customer customer2 = new Customer() { Name = "Alexander Rasmussen", Password = "alexergrim", PhoneNo = "27317110" };
                    var post = client.PostAsJsonAsync("Api/Customers", customer2).Result;
                    Console.WriteLine(post.StatusCode);

                    //Dette er delete metoden            
                    var delete = client.DeleteAsync("api/Customers/20").Result;

                    //Dette er put metoden
                    //Customer customer1 = new Customer() { Id = 1, Name = "Michel Møs Arbirk", Password = "mosemanden", PhoneNo = "71909747" };
                    //var put = client.PutAsJsonAsync("api/Customers/1", customer1).Result;

                    //Dette er get metoden
                    var response = client.GetAsync("api/Customers").Result;
                    Console.WriteLine(response);
                    if (response.IsSuccessStatusCode)
                    {
                        var customers = response.Content.ReadAsAsync<IEnumerable<Customer>>().Result;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            
        }
    }
}
