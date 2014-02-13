using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ToDo.Models
{
    public class Task : Project
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public State Status { get; set; }

        public Task()
        {
        }

        //public Task(string name, string description, string status)
        //    : this(name, description, (State)Enum.Parse(typeof(State), status))
        //{
        //}

        public Task(string projectId, string name, string description)
            : this(projectId, name, description, "")
        {
        }

        public Task(string projectId, string name, string description, string status)
            : this(projectId, name, description, Task.StateFromString(status))
        {
        }

        public Task(string projectId, string name, string description, State status)
        {
            ProjectId = projectId;
            Name = name;
            Description = description;
            Status = status;
        }

        public static State StateFromString(string status)
        {
            return status.Equals("Doing") ? State.Doing : (status.Equals("Done") ? State.Done : State.ToDo);
        }

    }

    public enum State
    {
        ToDo, Doing, Done
    }
}