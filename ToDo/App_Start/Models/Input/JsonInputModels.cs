using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToDo.Models.Input
{
    //JsonMessage is needed if there is no output model for the web method
    public class SaveTaskJsonInput
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class UpdateTaskJsonInput
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Id { get; set; }
        public string Status { get; set; }
    }
    public class RemoveTaskJsonInput
    {
        public string Id { get; set; }
    }
}