using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Popups;
using MUAH.Model;
using Newtonsoft.Json;

namespace MUAH.PersistencyService
{
    class PersistencyServiceAdmin 
    {
        private static string adminFileName = "Admins.json";

        /// <summary>
        /// JSON står for JavaScript Object Notation - JSON bliver brugt når data bliver sendt fra en server til en hjemmeside.
        /// JSON er nemt for maskiner og systemer at genere om til læseligt materiale for mennesker.
        /// Denne metode bruges til at gemme en collection af customers til databasen. 
        /// </summary>
        /// <param name="customers"></param>
        public static async void SaveAdminsAsJsonAsync(ObservableCollection<Admin> admins)
        {
            string adminsJsonString = JsonConvert.SerializeObject(admins);
            SerializeCustomersFileAsync(adminsJsonString, adminFileName);
        }

        /// <summary>
        /// Her gemmer den en lokal fil, hvis der er en eksisterende bliver denne erstattet.
        /// </summary>
        /// <param name="customersString"></param>
        /// <param name="fileName"></param>
        public static async void SerializeAdminsFileAsync(string adminsString, string fileName)
        {
            StorageFile localFile =
                await ApplicationData.Current.LocalFolder.CreateFileAsync(fileName,
                    CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(localFile, adminsString);
        }

        /// <summary>
        /// Her henter den en lokal fil, og returnere filen. OBS IKKE 100% SIKRE PÅ DETTE.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>Hvis den ikke kan finde filen returnere den null ellers returneres filen</returns>
        public static async Task<string> DeSerializeAdminsFileAsync(String fileName)
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

        /// <summary>
        /// serverUrl er konstant når man har sat den
        /// metoden henter listen af kunder fra databasen via http. 
        /// </summary>
        /// <returns> returnere de kunder der allerede er oprettet i databasen</returns>
        public static async Task<List<Admin>> GetAdminAsync()
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(Helper.ServerUrl);
                client.DefaultRequestHeaders.Clear();

                try
                {
                    var response = client.GetAsync("api/Admins").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var admins = await response.Content.ReadAsAsync<IEnumerable<Admin>>();
                        return (List<Admin>)admins;
                    }

                    return null;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Tilføjer en customer til databasen via web api ved brug af HTTP. 
        /// </summary>
        /// <param name="customers">customer objektet der skal tilføjes</param>
        public static async void PostAdminAsync(Admin admins)
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(Helper.ServerUrl);
                client.DefaultRequestHeaders.Clear();
                try
                {
                    var post = await client.PostAsJsonAsync("Api/Admins", admins);
                }
                catch (Exception e)
                {
                    new MessageDialog(e.Message).ShowAsync();
                }
            }
        }

        /// <summary>
        /// Ændrer et customer objekt i databasen via web api ved brug af HTTP.
        /// Det nye customer objekt erstatter det gamle, med de nye ændringer. 
        /// </summary>
        /// <param name="customers">det nye customer objekt</param>
        public static async void PutAdminAsync(Admin admins)
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(Helper.ServerUrl);
                client.DefaultRequestHeaders.Clear();

                try
                {
                    var put = await client.PutAsJsonAsync("api/admins/" + admins.CVRNo, admins);
                }
                catch (Exception e)
                {
                    new MessageDialog(e.Message).ShowAsync();
                }
            }
        }

        /// <summary>
        /// Sletter et customer objekt fra databasen via web api ved brug af HTTP. 
        /// </summary>
        /// <param name="customers">customer objekt der skal slettes</param>
        public static async void DeleteAdminAsync(Admin admins)
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(Helper.ServerUrl);
                client.DefaultRequestHeaders.Clear();

                try
                {
                    var delete = await client.DeleteAsync("api/admins/" + admins.Id);
                }
                catch (Exception e)
                {
                    new MessageDialog(e.Message).ShowAsync();
                }
            }
        }
    }
}
