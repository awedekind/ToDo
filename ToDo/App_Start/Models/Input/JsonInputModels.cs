using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToDo.Models.Input
{
    //JsonMessage is needed if there is no output model for the web method
    public class SaveJsonInput
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ProjectId { get; set; }
    }

    public class IdJsonInput
    {
        public string Id { get; set; }
    }

    public class UpdateJsonInput
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Id { get; set; }
        public string ProjectId { get; set; }
    }

    public class UpdateProjectJsonInput : UpdateJsonInput
    {
        public IList<Task> Tasks { get; set; }
        public Task Task { get; set; }
    }

    public class UpdateTaskJsonInput : UpdateJsonInput
    {
        public string Status { get; set; }
    }
}