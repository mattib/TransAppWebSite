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
    public class TasksDataSource : TransAppDataSource
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
            var result = string.Empty;
            using (var client = new WebClient())
            {
                var reqparm = new System.Collections.Specialized.NameValueCollection();
                reqparm.Add("Id", task.Id.ToString());
                reqparm.Add("DeliveryNumber", task.DeliveryNumber);
                reqparm.Add("UserId", task.UserId.ToString());
                reqparm.Add("CompanyId", task.CompanyId.ToString());
                reqparm.Add("SenderAddressId", task.SenderAddressId.ToString());
                reqparm.Add("ReciverAddressId", task.ReciverAddressId.ToString());
                reqparm.Add("TaskStatus", task.TaskStatus.ToString());
                reqparm.Add("Created", task.Created.ToString());
                reqparm.Add("PickedUpAt", task.PickedUpAt.ToString());
                reqparm.Add("DeliveredAt", task.DeliveredAt.ToString());
                reqparm.Add("PickUpTime", task.PickUpTime.ToString());
                reqparm.Add("DeliveryTime", task.DeliveryTime.ToString());
                reqparm.Add("Accepted", task.Accepted.ToString());
                reqparm.Add("PackageType", task.PackageType.ToString());
                reqparm.Add("Comment", task.Comment.ToString());
                reqparm.Add("RejectionReason", task.RejectionReason.ToString());
                reqparm.Add("ContactId", task.ContactId.ToString());
                reqparm.Add("TaskType", task.TaskType.ToString());
                reqparm.Add("DataExtention", task.DataExtention);
                var responsebytes = client.UploadValues(m_tasksUrl, "POST", reqparm);
                string responsebody = Encoding.UTF8.GetString(responsebytes);
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