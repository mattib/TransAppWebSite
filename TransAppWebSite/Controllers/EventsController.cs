using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using TransAppWebSite.DataSources;
using TransAppWebSite.Models;

namespace TransAppWebSite.Controllers
{
    public class EventsController : Controller
    {
        private EventsDataSource m_eventsDataSource = new EventsDataSource();

        //public EventsController()
        //{
        //    var m_eventsDataSource = new EventsDataSource();
        //}

        public ActionResult Index()
        {
            var events = m_eventsDataSource.GetAllEvents();

            var eventsModel = new EventsModel();
            eventsModel.Events = events.Select(eventItem => new EventViewModel(eventItem)).ToArray();
            return View(eventsModel);
        }

        public ActionResult Edit(int id)
        {
            var eventItem = m_eventsDataSource.GetEvent(id);
            var eventViewModel = new EventViewModel(eventItem);
            return View(eventViewModel);
        }

        [HttpPost]
        public ActionResult Edit(EventViewModel eventItem)
        {
            m_eventsDataSource.SaveEvent(eventItem.ToEvent());

            return RedirectToAction("Index");
        }

        public ActionResult New()
        {
            var eventItem = new Event();
            var eventViewModel = new EventViewModel(eventItem);
            return View(eventViewModel);
        }

        [HttpPost]
        public ActionResult New(EventViewModel eventItem)
        {

            m_eventsDataSource.SaveEvent(eventItem.ToEvent());

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            m_eventsDataSource.DeleteEvent(id);

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var eventItem = m_eventsDataSource.GetEvent(id);
            var eventViewModel = new EventViewModel(eventItem);
            return View(eventViewModel);
        }
    }
}
