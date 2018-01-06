using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using Server.Helper;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Server.Models;
using System.Collections.ObjectModel;
using SignalRServer.Models;

namespace Server.Controllers
{
    public class ChatController : Controller
    {
        // GET: Chat
        public async Task<ActionResult> Index()
        {
            var client = ChatHttpClient.GetClient();
                //var model = JsonConvert.DeserializeObject<IEnumerable<MessageModel>>(content);
            HttpResponseMessage response = await client.GetAsync("api/SignalRMessages");
            ObservableCollection<MessageModel> temp = new ObservableCollection<MessageModel>();
            if (response.IsSuccessStatusCode)
            {
                temp = await response.Content.ReadAsAsync<ObservableCollection<MessageModel>>();
                return View(temp);
            }
            else
                return Content("Der er sket en fejl...");
                
        }

        // GET: Chat/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Chat/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Chat/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Chat/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Chat/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Chat/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Chat/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
