using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TransAppWebSite.DataSources;
using TransAppWebSite.Models;

namespace TransAppWebSite.Controllers
{
    public class UsersController : Controller
    {
        private UsersDataSource m_usersDataSource = new UsersDataSource();

        //public UserController()
        //{
        //    var m_eventsDataSource = new UsersDataSource();
        //}

        public ActionResult Index()
        {
            var users = m_usersDataSource.GetAllUsers();

            var usersModel = new UsersModel();
            usersModel.Users = users.ToArray();
            return View(usersModel);
        }

        public ActionResult Edit(int id)
        {
            var eventItem = m_usersDataSource.GetUser(id);

            return View(eventItem);
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {
            m_usersDataSource.SaveUser(user);

            return RedirectToAction("Index");
        }

        public ActionResult New()
        {
            var user = new User();

            return View(user);
        }

        [HttpPost]
        public ActionResult New(User user)
        {
            m_usersDataSource.SaveUser(user);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            m_usersDataSource.DeleteUser(id);

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var user = m_usersDataSource.GetUser(id);

            return View(user);
        }
    }
}
