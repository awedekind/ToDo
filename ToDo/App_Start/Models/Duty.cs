using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ToDo.Models
{
    public class Duty
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public State Status { get; set; }

        public Duty() { }

        public Duty(string name, string description)
            : this(name, description, "")
        {
        }

        public Duty(string name, string description, string status)
            : this(name, description, Duty.StateFromString(status))
        {
        }

        public Duty(string name, string description, State status)
        {
            Name = name;
            Description = description;
            Status = status;
        }

        public static State StateFromString(string status)
        {
            return status.Equals("Doing") ? State.Doing : (status.Equals("Done") ? State.Done : State.Todo);
        }

    }

    public enum State
    {
        Todo, Doing, Done
    }
}
