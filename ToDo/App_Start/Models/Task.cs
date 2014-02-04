using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToDo.Models
{
    public class Task
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public State Status { get; set; }

        public Task()
        {
        }

        //public Task(string name, string description, string status)
        //    : this(name, description, (State)Enum.Parse(typeof(State), status))
        //{
        //}

				public Task(string name, string description)
            : this(name, description, "")
        {
        }

				public Task(string name, string description, string status)
            : this(name, description, Task.StateFromString(status))
        {
        }

        public Task(string name, string description, State status)
        {
            Name = name;
            Description = description;
            Status = status;
        }

        public static State StateFromString(string status)
        {
            if (status.Equals("Doing"))
            {
                return State.Doing;
            }
            else if (status.Equals("Done"))
            {
                return State.Done;
            }
            return State.ToDo;
        }

    }

    public enum State
    {
        ToDo, Doing, Done
    }
}