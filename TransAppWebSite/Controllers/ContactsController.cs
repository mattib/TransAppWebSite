using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;
using TransAppWebSite.Filters;
using TransAppWebSite.Models;
using TransAppWebSite.DataSources;

namespace TransAppWebSite.Controllers
{
    public class ContactsController : Controller
    {
        private ContactsDataSource m_contactsDataSource = new ContactsDataSource();

        public ActionResult Index()
        {
            var events = m_contactsDataSource.GetAllContacts();

            var contactModel = new ContactsModel {Contacts = events.ToArray()};
            return View(contactModel);
        }

        public ActionResult Edit(int id)
        {
            var contact = m_contactsDataSource.GetContact(id);

            return View(contact);
        }

        [HttpPost]
        public ActionResult Edit(Contact contact)
        {
            m_contactsDataSource.SaveContact(contact);

            return RedirectToAction("Index");
        }

        public ActionResult New()
        {
            var contact = new Contact {Address = new Address()};

            return View(contact);
        }

        [HttpPost]
        public ActionResult New(Contact contact)
        {
            m_contactsDataSource.SaveContact(contact);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            m_contactsDataSource.DeleteContact(id);

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var contact = m_contactsDataSource.GetContact(id);

            return View(contact);
        }
    }
}
