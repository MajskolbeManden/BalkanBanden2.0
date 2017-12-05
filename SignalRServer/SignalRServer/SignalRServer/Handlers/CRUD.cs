using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalRServer.Models;
using System.Net.Http;
using System.Net.Http.Headers;

namespace SignalRServer.Handlers
{
    public class CRUD
    {
        private const string serverUrl = "http://signalrrestchatap.azurewebsites.net";

        public static async Task<ObservableCollection<ChatMessage>> GetMessages()
        {
            ObservableCollection<ChatMessage> tempList = new ObservableCollection<ChatMessage>();

            //Using bruges til når man har en forbindelse åben fortsættelse følger.
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //lidt i tvivl om denne
                client.DefaultRequestHeaders.Clear();
                client.BaseAddress = new Uri(serverUrl);

                try
                {
                    HttpResponseMessage response = await client.GetAsync("api/SignalRMessages");

                    if (response.IsSuccessStatusCode)
                    {
                        tempList = await response.Content.ReadAsAsync<ObservableCollection<ChatMessage>>();
                    }
                }
                catch (Exception e)
                {

                    throw;
                }
                return tempList;
            }            
        }
    }
}
