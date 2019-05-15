using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using MUAH.Model;
using Newtonsoft.Json;

namespace MUAH.PersistencyService
{
    class PersistencyServiceBasket
    {

        private static string basketFileName = "Baskets.json";

        public static async Task<List<CustomerSession>> GetBasketAsync()
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(Helper.ServerUrl);
                client.DefaultRequestHeaders.Clear();

                try
                {
                    var response = client.GetAsync("Api/Baskets").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var baskets = await response.Content.ReadAsAsync<IEnumerable<CustomerSession>>();
                        return (List<CustomerSession>) baskets;
                    }

                    return null;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }

        public static async void PostBasketAsync(CustomerSession basket)
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(Helper.ServerUrl);
                client.DefaultRequestHeaders.Clear();
                try
                {
                    var post = await client.PostAsJsonAsync("Api/Customers", basket);
                }
                catch (Exception e)
                {
                    new MessageDialog(e.Message).ShowAsync();
                }
            }
        }

        public static async void PutBasketAsync(CustomerSession basket)
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(Helper.ServerUrl);
                client.DefaultRequestHeaders.Clear();

                try
                {
                    var put = await client.PutAsJsonAsync("api/customers/" + basket.SessionId, basket);
                }
                catch (Exception e)
                {
                    new MessageDialog(e.Message).ShowAsync();
                }
            }
        }

        public static async void DeleteBasketAsync(CustomerSession basket)
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(Helper.ServerUrl);
                client.DefaultRequestHeaders.Clear();

                try
                {
                    var delete = await client.DeleteAsync("api/customers/" + basket.SessionId);
                }
                catch (Exception e)
                {
                    new MessageDialog(e.Message).ShowAsync();
                }
            }
        }
    }
}
