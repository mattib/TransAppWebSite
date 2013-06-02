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
    public static class EventsExtentions
    {
        public static HtmlString EventsGrid(this HtmlHelper htmlHelper, Event[] events)
        {

            var stringWriter = new StringWriter();

            using (var writer = new HtmlTextWriter(stringWriter))
            {
                writer.RenderBeginTag(HtmlTextWriterTag.Table);

                writer.RenderBeginTag(HtmlTextWriterTag.Tr);
                writer.RenderBeginTag(HtmlTextWriterTag.Td);
                writer.Write("Event Id");
                writer.RenderEndTag();
                writer.RenderBeginTag(HtmlTextWriterTag.Td);
                writer.Write("Event Text");
                writer.RenderEndTag();
                writer.RenderBeginTag(HtmlTextWriterTag.Td);
                writer.Write("Event Time");
                writer.RenderEndTag();
                writer.RenderBeginTag(HtmlTextWriterTag.Td);
                writer.Write("Event User Id");
                writer.RenderEndTag();
                writer.RenderBeginTag(HtmlTextWriterTag.Td);
                writer.Write("Event Task Id");
                writer.RenderEndTag();
                writer.RenderBeginTag(HtmlTextWriterTag.Td);
                writer.Write("Event Type number");
                writer.RenderEndTag();
                writer.RenderBeginTag(HtmlTextWriterTag.Td);
                writer.Write("Event Details");
                writer.RenderEndTag();
                writer.RenderBeginTag(HtmlTextWriterTag.Td);
                writer.Write("Update Event");
                writer.RenderEndTag();
                writer.RenderBeginTag(HtmlTextWriterTag.Td);
                writer.Write("Delete Event");
                writer.RenderEndTag();
                writer.RenderEndTag();

                foreach (var item in events)
                {
                    writer.RenderBeginTag(HtmlTextWriterTag.Tr);
                    writer.RenderBeginTag(HtmlTextWriterTag.Td);
                    writer.Write(item.Id.ToString());
                    writer.RenderEndTag();
                    writer.RenderBeginTag(HtmlTextWriterTag.Td);
                    writer.Write(item.Text);
                    writer.RenderEndTag();
                    writer.RenderBeginTag(HtmlTextWriterTag.Td);
                    writer.Write(item.Time.ToString("dd-MM-yyyy HH:mm"));
                    writer.RenderEndTag();
                    writer.RenderBeginTag(HtmlTextWriterTag.Td);
                    writer.Write(item.UserId.ToString());
                    writer.RenderEndTag();
                    writer.RenderBeginTag(HtmlTextWriterTag.Td);
                    writer.Write(item.TaskId.ToString());
                    writer.RenderEndTag();
                    writer.RenderBeginTag(HtmlTextWriterTag.Td);
                    var tt = (EventType)item.EventType;
                    writer.Write(((EventType)item.EventType).ToString());
                    writer.RenderEndTag();
                    writer.RenderBeginTag(HtmlTextWriterTag.Td);
                    writer.AddAttribute(HtmlTextWriterAttribute.Href, "/Events/Details/" + item.Id);
                    writer.RenderBeginTag(HtmlTextWriterTag.A);
                    writer.Write("Details");
                    writer.RenderEndTag();
                    writer.RenderEndTag();
                    writer.RenderBeginTag(HtmlTextWriterTag.Td);
                    writer.AddAttribute(HtmlTextWriterAttribute.Href, "/Events/Edit/" + item.Id);
                    writer.RenderBeginTag(HtmlTextWriterTag.A);
                    writer.Write("Update");
                    writer.RenderEndTag();
                    writer.RenderEndTag();
                    writer.RenderBeginTag(HtmlTextWriterTag.Td);
                    writer.AddAttribute(HtmlTextWriterAttribute.Href, "/Events/Delete/" + item.Id);
                    writer.RenderBeginTag(HtmlTextWriterTag.A);
                    writer.Write("Delete");
                    writer.RenderEndTag();
                    writer.RenderEndTag();
                    writer.RenderEndTag();
                }
                writer.RenderEndTag();
            }

            return new HtmlString(stringWriter.ToString());
        }

    }
}