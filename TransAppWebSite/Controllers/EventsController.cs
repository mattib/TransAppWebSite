using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using TransAppWebSite.Models;

namespace TransAppWebSite.Controllers
{
    public class EventsController : Controller
    {
        private string m_eventUrl;

        public EventsController()
        {
            var apiServiceAddress = ConfigurationManager.AppSettings.Get("ApiServiceAddress");

            m_eventUrl = apiServiceAddress + "/event";
        }

        public ActionResult Index()
        {
            var result = string.Empty;
            using (var client = new WebClient())
            {
                var data = client.OpenRead(m_eventUrl);
                var reader = new StreamReader(data);
                result = reader.ReadToEnd();
            }

            var events = (List<Event>)Newtonsoft.Json.JsonConvert.DeserializeObject(result, typeof(List<Event>));


            var eventsModel = new EventsModel();
            eventsModel.Events = events.ToArray();
            return View(eventsModel);
        }

        public ActionResult Edit(int id)
        {
            var eventItem = GetEvent(id);

            return View(eventItem);
        }

        [HttpPost]
        public ActionResult Edit(Event eventItem)
        {
            SaveEvent(eventItem);

            return RedirectToAction("Index");
        }

        public ActionResult New()
        {
            var eventItem = new Event();

            return View(eventItem);
        }

        [HttpPost]
        public ActionResult New(Event eventItem)
        {
            SaveEvent(eventItem);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            DeleteEvent(id);

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var eventItem = GetEvent(id);

            return View(eventItem);
        }

        private Event GetEvent(int id)
        {
            var result = string.Empty;
            using (var client = new WebClient())
            {
                var eventUrl = m_eventUrl + "/" + id;
                var data = client.OpenRead(eventUrl);
                var reader = new StreamReader(data);
                result = reader.ReadToEnd();
            }

            var eventItem = (Event)Newtonsoft.Json.JsonConvert.DeserializeObject(result, typeof(Event));
            return eventItem;
        }

        private void SaveEvent(Event eventItem)
        {
            var result = string.Empty;
            using (var client = new WebClient())
            {
                var reqparm = new System.Collections.Specialized.NameValueCollection();
                reqparm.Add("Id", eventItem.Id.ToString());
                reqparm.Add("Text", eventItem.Text);
                reqparm.Add("Time", eventItem.Time.ToString());
                reqparm.Add("UserId", eventItem.Text.ToString());
                reqparm.Add("InputType", eventItem.InputType.ToString());
                reqparm.Add("RowStatus", eventItem.RowStatus.ToString());
                reqparm.Add("EventType", eventItem.EventType.ToString());
                reqparm.Add("TaskId", eventItem.TaskId.ToString());
                var responsebytes = client.UploadValues(m_eventUrl, "POST", reqparm);
                string responsebody = Encoding.UTF8.GetString(responsebytes);
            }
        }

        private void DeleteEvent(int id)
        {
            using (var client = new WebClient())
            {
                var eventUrl = m_eventUrl + "/" + id;
                client.UploadString(eventUrl, "DELETE", string.Empty);
            }
        }
    }
}
