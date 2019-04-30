using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Popups;
using MUAH.Model;
using Newtonsoft.Json;

namespace MUAH.PersistencyService
{
    class PersistencyServiceCustomer
    {
        private static string customerFileName = "Customers.json";

        public static async void SaveCustomersAsJsonAsync(ObservableCollection<Customer> customers)
        {
            string customersJsonString = JsonConvert.SerializeObject(customers);
            SerializeCustomersFileAsync(customersJsonString, customerFileName);
        }

        public static async void SerializeCustomersFileAsync(string customersString, string fileName)
        {
            StorageFile localFile =
                await ApplicationData.Current.LocalFolder.CreateFileAsync(fileName,
                    CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(localFile, customersString);
        }

        public static async Task<string> DeSerializeEventsFileAsync(String fileName)
        {
            try
            {
                StorageFile localFile = await ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
                return await FileIO.ReadTextAsync(localFile);
            }
            catch (FileNotFoundException ex)
            {
                //MessageDialogHelper.Show("File of customers not found! - Loading for the first time?", "File not found!");
                return null;
            }
        }

        public static async Task<List<Customer>> GetCustomerAsync()
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
                        var customers = await response.Content.ReadAsAsync<IEnumerable<Customer>>();
                        return (List<Customer>) customers;
                    }

                    return null;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }

        public static async void PostCustomerAsync(Customer customers)
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
                    var post = await client.PostAsJsonAsync("Api/Customers", customers);
                }
                catch (Exception e)
                {
                    new MessageDialog(e.Message).ShowAsync();
                }
            }
        }

        public static async void PutCustomerAsync(Customer customers)
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
                    var put = await client.PutAsJsonAsync("api/customers/" + customers.PhoneNo, customers);
                }
                catch (Exception e)
                {
                    new MessageDialog(e.Message).ShowAsync();
                }
            }
        }

        public static async void DeleteCustomerAsync(Customer customers)
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
                    var delete = await client.DeleteAsync("api/customers/" + customers.Id);
                }
                catch (Exception e)
                {
                    new MessageDialog(e.Message).ShowAsync();
                }
            }
        }

    }
}
