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
    public class CompaniesController : Controller
    {
        private CompaniesDataSource m_companiesDataSource = new CompaniesDataSource();

        //public EventsController()
        //{
        //    var m_addressesDataSource = new EventsDataSource();
        //}

        public ActionResult Index()
        {
            var companies = m_companiesDataSource.GetAllCompanies();

            var companiesModel = new CompaniesModel();
            companiesModel.Companies = companies.ToArray();
            return View(companiesModel);
        }

        public ActionResult Edit(int id)
        {
            var company = m_companiesDataSource.GetCompany(id);

            return View(company);
        }

        [HttpPost]
        public ActionResult Edit(Company company)
        {
            m_companiesDataSource.SaveCompany(company);

            return RedirectToAction("Index");
        }

        public ActionResult New()
        {
            var company = new Company {Address = new Address()};

            return View(company);
        }

        [HttpPost]
        public ActionResult New(Company company)
        {
            m_companiesDataSource.SaveCompany(company);
            
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            m_companiesDataSource.DeleteCompany(id);

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var company = m_companiesDataSource.GetCompany(id);

            return View(company);
        }
    }
}
