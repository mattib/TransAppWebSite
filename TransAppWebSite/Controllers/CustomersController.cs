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
    public class CustomersController : Controller
    {
        private CustomersDataSource m_customersDataSource = new CustomersDataSource();

        //public EventsController()
        //{
        //    var m_addressesDataSource = new EventsDataSource();
        //}

        public ActionResult Index()
        {
            var customers = m_customersDataSource.GetAllCustomers();

            var companiesModel = new CustomersModel();
            companiesModel.Customers = customers.ToArray();
            return View(companiesModel);
        }

        public ActionResult Edit(int id)
        {
            var customer = m_customersDataSource.GetCustomer(id);

            return View(customer);
        }

        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            m_customersDataSource.SaveCustomer(customer);

            return RedirectToAction("Index");
        }

        public ActionResult New()
        {
            var customer = new Customer {Address = new Address(), Contact = new Contact()};

            return View(customer);
        }

        [HttpPost]
        public ActionResult New(Customer customer)
        {
            m_customersDataSource.SaveCustomer(customer);
            
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            m_customersDataSource.DeleteCustomer(id);

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var customer = m_customersDataSource.GetCustomer(id);

            return View(customer);
        }
    }
}
