﻿using Raven.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using ToDo.App_Start.Models;

namespace ToDo.App_Start.Controllers
{
    public class HomeController
    {
        private readonly IRavenController _raven;
        //public HomeController() { _raven = new RavenController(); }
        //public HomeController() { }
        public HomeController(IRavenController raven)
        {
            _raven = raven;
        }
        public TaskPageViewModel get_Index()
        {
            List<Task> tasks = _raven.LoadAllTasks();
            return new TaskPageViewModel(tasks);
        }
        public TaskPageViewModel UpdateTask_NameVal_DescriptionVal_IdVal_StatusVal(TaskInputModel input)
        {
            var task = new Task(input.Name, input.Description, input.Status);
            task.Id = input.Id;
            _raven.RemoveTask(input.Id);
            _raven.SaveTask(task);
            Thread.Sleep(100);
            List<Task> tasks = _raven.LoadAllTasks();
            var taskPage = new TaskPageViewModel(tasks);
            return taskPage;
        }
        public TaskPageViewModel NewTask_NameVal_DescriptionVal(UrlSaveUpdateInputModel input)
        {
            _raven.SaveTask(new Task(input.NameVal, input.DescriptionVal, State.ToDo));
            Thread.Sleep(100);
            List<Task> tasks = _raven.LoadAllTasks();
            var taskPage = new TaskPageViewModel(tasks);
            return taskPage;
        }
        public TaskPageViewModel RemoveTask_TypeVal_IdVal(UrlIdInputModel input)
        {
            string id = input.TypeVal + "/" + input.IdVal;
            _raven.RemoveTask(id);
            Thread.Sleep(100);
            return new TaskPageViewModel(_raven.LoadAllTasks());
        }
    }
    public class UrlSaveUpdateInputModel
    {
        public string NameVal { get; set; }
        public string DescriptionVal { get; set; }
        public string IdVal { get; set; }
        public string StatusVal { get; set; }
    }
    public class UrlIdInputModel
    {
        public string TypeVal { get; set; }
        public int IdVal { get; set; }
    }
}