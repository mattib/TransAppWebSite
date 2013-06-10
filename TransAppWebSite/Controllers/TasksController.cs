﻿using System;
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
    public class TasksController : Controller
    {
        private TasksDataSource m_tasksDataSource = new TasksDataSource();

        //public EventsController()
        //{
        //    var m_eventsDataSource = new EventsDataSource();
        //}

        public ActionResult Index()
        {
            var tasks = m_tasksDataSource.GetAllTasks();

            var tasksModel = new TasksModel();

            var taskList = new List<TaskViewModel>();

            foreach (var task in tasks)
            {
                var taskViewModel = new TaskViewModel(task);
                taskList.Add(taskViewModel);
            }

            tasksModel.Tasks = taskList.ToArray();
            return View(tasksModel);
        }

        public ActionResult Edit(int id)
        {
            var task = m_tasksDataSource.GetTask(id);

            return View(new TaskViewModel(task));
        }

        [HttpPost]
        public ActionResult Edit(TaskViewModel taskViewModel)
        {
            var task = taskViewModel.ToTask();
            m_tasksDataSource.SaveTask(task);

            return RedirectToAction("Index");
        }

        public ActionResult New()
        {
            var task = new Task();

            return View(task);
        }

        [HttpPost]
        public ActionResult New(Task task)
        {
            m_tasksDataSource.SaveTask(task);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            m_tasksDataSource.DeleteTask(id);

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var task = m_tasksDataSource.GetTask(id);

            return View(task);
        }
    }
}