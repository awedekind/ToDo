using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToDo.App_Start.Models
{
    public class TaskPageViewModel
    {
        public TaskPageViewModel() { }
        public TaskPageViewModel(List<Task> tasks)
        {
            Tasks = tasks;
        }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public List<Task> Tasks { get; set; }
    }
}