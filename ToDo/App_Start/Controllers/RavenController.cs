using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Raven.Client;
using ToDo.App_Start.Models;
using Raven.Client.Document;
using ToDo.App_Start.Controllers;

namespace ToDo.App_Start
{
    public class RavenController : IRavenController
    {
        private readonly IDocumentSession _session;
        //public RavenController() { }
        public RavenController(IDocumentSession session)
        {
            _session = session;
        }
        
        //public RavenController()
        //{
        //    var docStore = new DocumentStore
        //    {
        //        ConnectionStringName = "RavenDBConnection"
        //    }.Initialize();
        //    _session = docStore.OpenSession();
        //}

        public Task LoadTask(string id)
        {
            return _session.Load<Task>(id);
        }

        public void SaveTask(Task task)
        {
            if (task.Id != null)
            {
                Task oldTask = LoadTask(task.Id);
                oldTask = task;
                _session.Store(oldTask);
            }
            else
            {
                _session.Store(task);
            }
            _session.SaveChanges();
        }

        public void RemoveTask(string id)
        {
            try
            {
                Task oldTask = LoadTask(id);
                _session.Delete<Task>(oldTask);
                _session.SaveChanges();
            }
            catch (Exception ex) { Console.Error.WriteLine(ex.Message); }
        }

        public List<Task> LoadAllTasks()
        {
            return _session.Query<Task>().ToList();
        }
    }
}