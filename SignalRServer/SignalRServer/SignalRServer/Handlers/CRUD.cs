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
        private const string serverUrl = "http://signalrchatrestservice.azurewebsites.net";

        #region GET Messages
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
        #endregion
        #region GET Users
        public async Task<ObservableCollection<User>> GetUsers()
        {
            ObservableCollection<User> tempList = new ObservableCollection<User>();

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Clear();
                client.BaseAddress = new Uri(serverUrl);

                try
                {
                    HttpResponseMessage response = await client.GetAsync("api/SignalRUsers");
                    if (response.IsSuccessStatusCode)
                        tempList = await response.Content.ReadAsAsync<ObservableCollection<User>>();
                }
                catch (Exception e)
                {
                    //TODO: definere en exception der vises hvis kald ikke er succesfuldt
                    throw;
                }
            }

            return tempList;
        }
        #endregion
        #region GET Admins
        public async Task<ObservableCollection<Admin>> GetAdmins()
        {
            ObservableCollection<Admin> tempList = new ObservableCollection<Admin>();

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Clear();
                client.BaseAddress = new Uri(serverUrl);

                try
                {
                    HttpResponseMessage response = await client.GetAsync("api/SignalRAdmins");
                    if (response.IsSuccessStatusCode)
                        tempList = await response.Content.ReadAsAsync<ObservableCollection<Admin>>();
                }
                catch (Exception e)
                {
                    //TODO: definere en exception der vises hvis kald ikke er succesfuldt
                    throw;
                }
            }

            return tempList;
        }
        #endregion
        #region GET Groups
        public async Task<ObservableCollection<Group>> GetGroups()
        {
            ObservableCollection<Group> tempList = new ObservableCollection<Group>();

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Clear();
                client.BaseAddress = new Uri(serverUrl);

                try
                {
                    HttpResponseMessage response = await client.GetAsync("api/SignalRGroups");
                    if (response.IsSuccessStatusCode)
                        tempList = await response.Content.ReadAsAsync<ObservableCollection<Group>>();
                }
                catch (Exception e)
                {
                    //TODO: definere en exception der vises hvis kald ikke er succesfuldt
                    throw;
                }
            }

            return tempList;
        }
        #endregion
        #region PUT

        #endregion
        #region POST
        public static async void PostMessage(ChatMessage tempMessage)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    HttpResponseMessage response = await client.PostAsJsonAsync<ChatMessage>("api/SignalRMessages", tempMessage);
                }
                catch (Exception e)
                {
                    throw e;
                }

            }
        }
        #endregion

    }
}
