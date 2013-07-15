using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using TransAppWebSite.Models;

namespace TransAppWebSite.Utilities
{
    public static class TasksExtentions
    {
        public static HtmlString TasksGrid(this HtmlHelper htmlHelper, TaskViewModel[] tasks)
        {
            var stringWriter = new StringWriter();

            using (var writer = new HtmlTextWriter(stringWriter))
            {
                writer.RenderBeginTag(HtmlTextWriterTag.Table);

                writer.RenderBeginTag(HtmlTextWriterTag.Tr);
                writer.RenderBeginTag(HtmlTextWriterTag.Td);
                writer.Write("Deliver Number");
                writer.RenderEndTag();
                writer.RenderBeginTag(HtmlTextWriterTag.Td);
                writer.Write("User Name");
                writer.RenderEndTag();
                writer.RenderBeginTag(HtmlTextWriterTag.Td);
                writer.Write("Company Name");
                writer.RenderEndTag();
                writer.RenderBeginTag(HtmlTextWriterTag.Td);
                writer.Write("Sender Address");
                writer.RenderEndTag();
                writer.RenderBeginTag(HtmlTextWriterTag.Td);
                writer.Write("Reciver Address");
                writer.RenderEndTag();
                writer.RenderBeginTag(HtmlTextWriterTag.Td);
                writer.Write("Comment");
                writer.RenderEndTag();
                writer.RenderBeginTag(HtmlTextWriterTag.Td);
                writer.Write("Status");
                writer.RenderEndTag();
                writer.RenderBeginTag(HtmlTextWriterTag.Td);
                writer.Write("Last Modified");
                writer.RenderEndTag();
                writer.RenderBeginTag(HtmlTextWriterTag.Td);
                writer.Write("Task Details");
                writer.RenderEndTag();
                writer.RenderBeginTag(HtmlTextWriterTag.Td);
                writer.Write("Update Task");
                writer.RenderEndTag();
                writer.RenderBeginTag(HtmlTextWriterTag.Td);
                writer.Write("Delete Task");
                writer.RenderEndTag();
                writer.RenderEndTag();

                foreach (var task in tasks)
                {
                    var taskCompleted = task.TaskStatus == TaskStatus.Finished;
                    writer.RenderBeginTag(HtmlTextWriterTag.Tr);
                    writer.RenderBeginTag(HtmlTextWriterTag.Td);
                    writer.Write(task.DeliveryNumber);
                    writer.RenderEndTag();
                    writer.RenderBeginTag(HtmlTextWriterTag.Td);
                    writer.AddAttribute(HtmlTextWriterAttribute.Href, "/Users/Details/" + task.User.Id);
                    writer.RenderBeginTag(HtmlTextWriterTag.A);
                    writer.Write(task.User.FirstName + " " + task.User.LastName);
                    writer.RenderEndTag();
                    writer.RenderEndTag();
                    writer.RenderBeginTag(HtmlTextWriterTag.Td);
                    writer.AddAttribute(HtmlTextWriterAttribute.Href, "/Companies/Details/" + task.Company.Id);
                    writer.RenderBeginTag(HtmlTextWriterTag.A);
                    writer.Write(task.Company.Name);
                    writer.RenderEndTag();
                    writer.RenderEndTag();
                    writer.RenderBeginTag(HtmlTextWriterTag.Td);
                    var senderAddressString = GetAddressString(task.SenderAddress);
                    writer.Write(senderAddressString);
                    writer.RenderEndTag();
                    writer.RenderBeginTag(HtmlTextWriterTag.Td);
                    var reciverAddressString = GetAddressString(task.ReciverAddress);
                    writer.Write(reciverAddressString);
                    writer.RenderEndTag();
                    writer.RenderBeginTag(HtmlTextWriterTag.Td);
                    writer.Write(task.Comment);
                    writer.RenderEndTag();
                    writer.RenderBeginTag(HtmlTextWriterTag.Td);
                    writer.Write(Enum.GetName(task.TaskStatus.GetType(), task.TaskStatus));
                    writer.RenderEndTag();
                    writer.RenderBeginTag(HtmlTextWriterTag.Td);
                    writer.Write(task.LastModified.ToString("dd-MM-yyyy HH:mm"));
                    writer.RenderEndTag();
                    writer.RenderBeginTag(HtmlTextWriterTag.Td);
                    writer.AddAttribute(HtmlTextWriterAttribute.Href, "/Tasks/Details/" + task.Id);
                    writer.RenderBeginTag(HtmlTextWriterTag.A);
                    writer.Write("Details");
                    writer.RenderEndTag();
                    writer.RenderEndTag();
                    writer.RenderBeginTag(HtmlTextWriterTag.Td);
                    if (!taskCompleted)
                    {
                        
                        writer.AddAttribute(HtmlTextWriterAttribute.Href, "/Tasks/Edit/" + task.Id);
                        writer.RenderBeginTag(HtmlTextWriterTag.A);
                        writer.Write("Update");
                        writer.RenderEndTag();
                    }
                    writer.RenderEndTag();
                    writer.RenderBeginTag(HtmlTextWriterTag.Td);
                    if (!taskCompleted)
                    {
                        writer.AddAttribute(HtmlTextWriterAttribute.Href, "/Tasks/Delete/" + task.Id);
                        writer.RenderBeginTag(HtmlTextWriterTag.A);
                        writer.Write("Delete");
                        writer.RenderEndTag();
                    }
                    writer.RenderEndTag();
                    writer.RenderEndTag();
                }
                writer.RenderEndTag();
            }

            return new HtmlString(stringWriter.ToString());
        }

        private static string GetAddressString(Address address)
        {
            var result = string.Empty;

            if (address != null)
            {
                result = string.Format("{0} {1}, {2}", address.StreetName, address.StreetNumber, address.City);
            }
            return result;
        }

    }
}