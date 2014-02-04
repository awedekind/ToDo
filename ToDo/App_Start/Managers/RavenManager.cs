using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using Raven.Client;
using ToDo.Models;
using Raven.Client.Document;
using ToDo.Controllers;

namespace ToDo.Managers
{
    public class RavenManager : IRavenManager
    {
        private readonly IDocumentSession _session;

        public RavenManager(IDocumentSession session)
        {
            _session = session;
        }

        public Task LoadTask(string id)
        {
            return _session.Load<Task>(id);
        }

        public IList<Task> LoadAllTasks()
        {
            return _session.Query<Task>().ToList();
        }

        public Task SaveTask(Task task)
        {
            if (task.Id != null)
            {
                _session.Store(task, task.Id);
            }
            else
            {
                _session.Store(task);
            }
            _session.SaveChanges();

            return task;
        }

        public void RemoveTask(string id)
        {
            Task oldTask = LoadTask(id);
            _session.Delete(oldTask);
            _session.SaveChanges();
        }
    }
}