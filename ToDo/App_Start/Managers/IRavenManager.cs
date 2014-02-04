using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToDo.Models;

namespace ToDo.Managers
{
    public interface IRavenManager
    {
        IList<Task> LoadAllTasks();
        Task LoadTask(string id);
        Task SaveTask(Task task);
        void RemoveTask(string id);
    }
}
