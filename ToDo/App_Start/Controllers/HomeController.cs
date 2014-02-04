//using Raven.Client;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
using ToDo.Models;
using ToDo.Models.Input;
using ToDo.Models.Output;
using ToDo.Managers;
//using FubuCore;
//using FubuMVC.Core;

namespace ToDo.Controllers
{
    public class HomeController
    {
        private readonly IRavenManager _raven;

        public HomeController(IRavenManager raven)
        {
            _raven = raven;
        }

        public TaskPageViewModel get_Index()
        {
            //var tasks = _raven.LoadAllTasks();
            return new TaskPageViewModel();
        }

        public TaskListJsonResponse get_Tasks()
        {
            return new TaskListJsonResponse
            {
                Tasks = _raven.LoadAllTasks()
            };
        }

        public TaskJsonResponse post_UpdateTask(UpdateTaskJsonInput model)
        {
            var task = new Task
            {
                Name = model.Name,
                Description = model.Description,
                Id = model.Id,
                Status = Task.StateFromString(model.Status)
            };

            _raven.SaveTask(task);

            return new TaskJsonResponse
            {
                Task = task
            };
        }
        //public void post_UpdateTask_Name_Description_IdType_Id_Status(UrlSaveUpdateInputModel input)
        //{
        //    var task = new Task(input.Name, input.Description, input.Status);
        //    var id = input.GetId();
        //    task.Id = id;
        //    _raven.RemoveTask(id);
        //    _raven.SaveTask(task);
        //    //var tasks = _raven.LoadAllTasks();
        //    //var taskPage = new TaskPageViewModel(tasks);
        //    //return taskPage;
        //}

        public TaskJsonResponse post_NewTask(SaveTaskJsonInput model)
        {
            var task = _raven.SaveTask(new Task(model.Name, model.Description));

            //return new TaskListJsonResponse
            //{
            //    Tasks = _raven.LoadAllTasks()
            //};

            return new TaskJsonResponse
            {
                Task = task
            };
        }
        //public TaskPageViewModel put_NewTask_Name_Description(UrlSaveUpdateInputModel input)
        //{
        //    _raven.SaveTask(new Task(input.Name, input.Description, State.ToDo));
        //    var tasks = _raven.LoadAllTasks();
        //    return new TaskPageViewModel(tasks);
        //}

        public TaskListJsonResponse post_RemoveTask(RemoveTaskJsonInput model)
        {
            _raven.RemoveTask(model.Id);

            return new TaskListJsonResponse
            {
                Tasks = _raven.LoadAllTasks()
            };
        }
        //public TaskPageViewModel delete_RemoveTask_IdType_Id(UrlIdInputModel input)
        //{
        //    var id = input.GetId();
        //    _raven.RemoveTask(id);
        //    return new TaskPageViewModel(_raven.LoadAllTasks());
        //}
    }
}