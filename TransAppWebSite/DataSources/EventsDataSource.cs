using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using TransAppWebSite.Models;

namespace TransAppWebSite.DataSources
{
    public class EventsDataSource : TransAppDataSource
    {
        private string m_eventsUrl;

        public EventsDataSource()
        {
            m_eventsUrl = ApiServiceAddress + "/event";
        }

        public Event[] GetAllEvents()
        {
            var result = string.Empty;
            using (var client = new WebClient())
            {
                var data = client.OpenRead(m_eventsUrl);
                var reader = new StreamReader(data);
                result = reader.ReadToEnd();
            }

            var events = (List<Event>)Newtonsoft.Json.JsonConvert.DeserializeObject(result, typeof(List<Event>));

            return events.ToArray();
        }

        public Event GetEvent(int id)
        {
            var result = string.Empty;
            using (var client = new WebClient())
            {
                var eventUrl = m_eventsUrl + "/" + id;
                var data = client.OpenRead(eventUrl);
                var reader = new StreamReader(data);
                result = reader.ReadToEnd();
            }

            var eventItem = (Event)Newtonsoft.Json.JsonConvert.DeserializeObject(result, typeof(Event));
            return eventItem;
        }

        public void SaveEvent(Event eventItem)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(eventItem);
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
                var responsebytes = client.UploadValues(m_eventsUrl, "POST", reqparm);
                string responsebody = Encoding.UTF8.GetString(responsebytes);
            }
        }

        public void DeleteEvent(int id)
        {
            using (var client = new WebClient())
            {
                var eventUrl = m_eventsUrl + "/" + id;
                client.UploadString(eventUrl, "DELETE", string.Empty);
            }
        }
    }
}