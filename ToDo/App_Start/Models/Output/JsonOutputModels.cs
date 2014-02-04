using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToDo.Models.Output
{
    public class TaskListJsonResponse
    {
        public IList<Task> Tasks { get; set; }
    }

    public class TaskJsonResponse
    {
        public Task Task { get; set; }
    }
}