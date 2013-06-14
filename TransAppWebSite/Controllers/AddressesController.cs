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
   public class AddressesController : Controller
    {
       private AddressesDataSource m_addressesDataSource = new AddressesDataSource();

        //public EventsController()
        //{
        //    var m_addressesDataSource = new EventsDataSource();
        //}

        public ActionResult Index()
        {
            var addresses = m_addressesDataSource.GetAllAddresses();

            var addressesModel = new AddressesModel();
            addressesModel.Addresses = addresses.ToArray();
            return View(addressesModel);
        }

        public ActionResult Edit(int id)
        {
            var address = m_addressesDataSource.GetAddress(id);

            return View(address);
        }

        [HttpPost]
        public ActionResult Edit(Address address)
        {
            m_addressesDataSource.SaveAddress(address);

            return RedirectToAction("Index");
        }

        public ActionResult New()
        {
            var address = new Address();

            return View(address);
        }

        [HttpPost]
        public ActionResult New(Address address)
        {
            m_addressesDataSource.SaveAddress(address);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            m_addressesDataSource.DeleteAddress(id);

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var address = m_addressesDataSource.GetAddress(id);

            return View(address);
        }
    }
}
