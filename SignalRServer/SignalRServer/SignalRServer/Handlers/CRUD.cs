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
        //connection string til webservice
        //pt et test site; det bliver migreret når funktionalitet virker
        private const string serverUrl = "http://signalrrestchatap.azurewebsites.net";

        //liste der indeholder beskeder fra databasen
        public static async Task<ObservableCollection<ChatMessage>> GetMessages()
        {
            ObservableCollection<ChatMessage> tempList = new ObservableCollection<ChatMessage>();
            
            //i denne forbindelse bruges using til at åbne en forbindelse 
            //når vi skal foretage et kald til webservice
            //hvor den lukker forbindelsen igen når den er færdig
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
                    //TODO: definere en exception der vises hvis kald ikke er succesfuldt
                    throw;
                }
                return tempList;
            }            
        }
    }
}
