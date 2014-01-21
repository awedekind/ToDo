using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToDo.App_Start.Models
{
    public class Task
    {
        public Task()
        {

        }
        public Task(string name, string description, string status)
        {
            this.Name = name;
            this.Description = description;
            if (status.Equals("ToDo"))
            {
                this.Status = State.ToDo;
            }
            else if (status.Equals("Doing"))
            {
                this.Status = State.Doing;
            }
            else if (status.Equals("Done"))
            {
                this.Status = State.Done;
            }
        }
        public Task(string name, string description, State status)
        {
            this.Name = name;
            this.Description = description;
            this.Status = status;
        }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public State Status { get; set; }
    }
    public enum State
    {
        ToDo, Doing, Done
    }
}