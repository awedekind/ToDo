using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToDo.App_Start.Models
{
    public class TaskInputModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public State Status { get; set; }
    }
}