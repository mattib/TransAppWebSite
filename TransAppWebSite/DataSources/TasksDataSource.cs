using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using Newtonsoft.Json.Converters;
using TransAppWebSite.Models;

namespace TransAppWebSite.DataSources
{
    public class TasksDataSource : TransAppConfiguration
    {
        private string m_tasksUrl;

        public TasksDataSource()
        {
            m_tasksUrl = ApiServiceAddress + "/task";
        }

        public Task[] GetAllTasks()
        {
            var result = string.Empty;
            using (var client = new WebClient())
            {
                var data = client.OpenRead(m_tasksUrl);
                var reader = new StreamReader(data);
                result = reader.ReadToEnd();
            }

            var tasks = (List<Task>)Newtonsoft.Json.JsonConvert.DeserializeObject(result, typeof(List<Task>));

            return tasks.ToArray();
        }

        public Task GetTask(int id)
        {
            var result = string.Empty;
            using (var client = new WebClient())
            {
                var eventUrl = m_tasksUrl + "/" + id;
                var data = client.OpenRead(eventUrl);
                var reader = new StreamReader(data);
                result = reader.ReadToEnd();
            }

            var task = (Task)Newtonsoft.Json.JsonConvert.DeserializeObject(result, typeof(Task));
            return task;
        }

        public void SaveTask(Task task)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(task, new IsoDateTimeConverter());
            using (var client = new WebClient())
            {
                client.Headers.Add("Content-Type", "application/json");
                var responsebytes = client.UploadString(m_tasksUrl, "POST", json);
            }
        }

        public void DeleteTask(int id)
        {
            using (var client = new WebClient())
            {
                var taskUrl = m_tasksUrl + "/" + id;
                client.UploadString(taskUrl, "DELETE", string.Empty);
            }
        }
    }
}