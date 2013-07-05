using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TransAppWebSite.Models
{
    public class EventViewModel
    {
    
        public EventViewModel()
        {
        }

        public EventViewModel(Event eventItem)
        {
            this.Id = eventItem.Id;
            this.Text = eventItem.Text;
            this.Time = eventItem.Time;
            this.InputType = eventItem.InputType;
            this.RowStatus = eventItem.RowStatus;
            this.EventType = eventItem.EventType;
            if (eventItem.UserId.HasValue)
            {
                this.User = new User {Id = eventItem.UserId.Value};
            }
            if (eventItem.TaskId.HasValue)
            {
                this.Task = new Task { Id = eventItem.TaskId.Value };
            }
        }

        public Event ToEvent()
        {
            var eventItem = new Event();
            eventItem.Id = this.Id;
            eventItem.Text = this.Text;
            eventItem.Time = this.Time;
            eventItem.InputType = this.InputType;
            eventItem.EventType = this.EventType;
            if (this.User != null)
            {
                eventItem.UserId = this.User.Id;
            }
            if (this.Task != null)
            {
                eventItem.TaskId = this.Task.Id;
            }
            return eventItem;
        }

        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime Time { get; set; }
        public User User { get; set; }
        public int? InputType { get; set; }
        public int RowStatus { get; set; }
        public int? EventType { get; set; }
        public Task Task { get; set; }
    }
}