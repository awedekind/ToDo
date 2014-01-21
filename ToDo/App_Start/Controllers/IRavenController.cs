using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToDo.App_Start.Models;

namespace ToDo.App_Start.Controllers
{
    public interface IRavenController
    {
        IList<Task> LoadAllTasks();
        Task LoadTask(string id);
        void SaveTask(Task task);
        void RemoveTask(string id);
    }
}
