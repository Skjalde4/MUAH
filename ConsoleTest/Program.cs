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

            const string ServerUrl = "HTTP://localhost:58058";
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                try
                {
                    //Dette er post metoden for customer
                    Customer customer1 = new Customer(){Email = "Cersei@G" +
                                                                "ot.com", Name = "Cersei Lannister", Password = "Jaime", PhoneNo = "23506939"};
                    Customer customer2 = new Customer() { Email = "sdssa@grgg", Name = "Ilse Graff", Password = "ilse", PhoneNo = "40502688" };
                    var post = client.PostAsJsonAsync("Api/Customers", customer1).Result;
                    Console.WriteLine(post.StatusCode);

                    ////Dette er delete metoden            
                    ////var delete = client.DeleteAsync("api/Customers/20").Result;

                    ////Dette er put metoden
                    ////Customer customer1 = new Customer() { Id = 1, Name = "Michel Møs Arbirk", Password = "mosemanden", PhoneNo = "71909747" };
                    ////var put = client.PutAsJsonAsync("api/Customers/1", customer1).Result;

                    ////Dette er get metoden
                    var response = client.GetAsync("api/Customers").Result;
                    Console.WriteLine(response);
                    if (response.IsSuccessStatusCode)
                    {
                        var customers = response.Content.ReadAsAsync<IEnumerable<Customer>>().Result;
                    }

                    //Postmetoden for admin
                    //    Admin admin1 = new Admin() { CVRNo = 12345679, Password = "lars", Username = "larsG", Id = 1};
                    //    var post = client.PostAsJsonAsync("api/Admins", admin1).Result;
                    //    Console.WriteLine(post.StatusCode);

                    //    var response = client.GetAsync("api/Admins").Result;
                    //    Console.WriteLine(response);
                    //    if (response.IsSuccessStatusCode)
                    //    {
                    //        var admins = response.Content.ReadAsAsync<IEnumerable<Admin>>().Result;
                    //    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
    }
}
