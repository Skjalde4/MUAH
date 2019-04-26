using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using MUAH.Model;
using Newtonsoft.Json;

namespace MUAH.PersistencyService
{
    class PersistencyServiceCustomer
    {
        private static string customerFileName = "Customers.json";

        //public static async void SaveCustomersAsJsonAsync(ObservableCollection<Customer> customers)
        //{
        //    string customersJsonString = JsonConvert.SerializeObject(customers);
        //    SerializeCustomersFileAsync(customersJsonString, customerFileName)
        //}

        //public static async void SerializeCustomersFileAsync(string customersString, string fileName)
        //{
        //    StorageFile localFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
        //    await FileIO.WriteTextAsync(localFile, customersString);
        //}

        //public static async Task<string> DeSerializeEventsFileAsync(String fileName)
        //{
        //    try
        //    {
        //        StorageFile localFile = await ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
        //        return await FileIO.ReadTextAsync(localFile);
        //    }
        //    catch (FileNotFoundException ex)
        //    {

        //        //MessageDialogHelper.Show("File of customers not found! - Loading for the first time?", "File not found!");
        //        return null;
        //    }
        //}
    }
}
