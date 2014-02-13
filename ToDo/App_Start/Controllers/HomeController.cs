using System;
using ToDo.Models;
using ToDo.Models.Input;
using ToDo.Models.Output;
using ToDo.Managers;

namespace ToDo.Controllers
{
    public class HomeController
    {
        private readonly IRavenManager<Task> _ravenTaskManager;
        private readonly IRavenManager<Project> _ravenProjectManager;

        public HomeController(IRavenManager<Task> ravenTaskManager, IRavenManager<Project> ravenProjectManager)
        {
            _ravenTaskManager = ravenTaskManager;
            _ravenProjectManager = ravenProjectManager;
        }

        //public void setRavenTaskManager(IRavenManager<Task> irtm)
        //{
        //    _ravenTaskManager = irtm;
        //}

        /*Home Page*/
        public ProjectPageViewModel get_ProjectPage()
        {
            return new ProjectPageViewModel();
        }

        public TaskPageViewModel get_TaskPage_IdType_Id(TaskPageInput model)
        {
            return new TaskPageViewModel
            {
                Id = model.GetId()
            };
        }

        /*Task Endpoints*/
        public ListJsonResponse<Task> get_Tasks()
        {
            return new ListJsonResponse<Task>
            {
                Items = _ravenTaskManager.LoadAll()
            };
        }

        public ItemJsonResponse<Task> post_TaskNew(SaveJsonInput model)
        {
            var task = _ravenTaskManager.Save(new Task(model.ProjectId, model.Name, model.Description), null);

            return new ItemJsonResponse<Task>
            {
                Item = task
            };
        }

        public ItemJsonResponse<Task> post_TaskUpdate(UpdateTaskJsonInput model)
        {
            var task = new Task
            {
                Name = model.Name,
                Description = model.Description,
                Id = model.Id,
                ProjectId = model.ProjectId,
                Status = Task.StateFromString(model.Status)
            };

            _ravenTaskManager.Save(task, task.Id);

            return new ItemJsonResponse<Task>
            {
                Item = task
            };
        }

        public IdJsonOutput post_TaskRemove(IdJsonInput model)
        {
            var id = _ravenTaskManager.Remove(model.Id);

            return new IdJsonOutput
            {
                Id = id
            };
        }

        /*Project Endpoints*/
        public ListJsonResponse<Project> get_Projects()
        {
            return new ListJsonResponse<Project>
            {
                Items = _ravenProjectManager.LoadAll()
            };
        }

        public ListJsonResponse<Task> post_ProjectTasks(IdJsonInput model)
        {
            var tasks = _ravenTaskManager.LoadMany(model.Id);

            return new ListJsonResponse<Task>
            {
                Items = tasks
            };
        }

        public ItemJsonResponse<Project> post_ProjectNew(SaveJsonInput model)
        {
            var project = new Project
            {
                Name = model.Name,
                Description = model.Description
            };

            project = _ravenProjectManager.Save(project, null);

            return new ItemJsonResponse<Project>
            {
                Item = project
            };
        }

        public ItemJsonResponse<Project> post_ProjectUpdate(UpdateProjectJsonInput model)
        {
            var project = new Project
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
            };

            _ravenProjectManager.Save(project, project.Id);

            return new ItemJsonResponse<Project>
            {
                Item = project
            };
        }

        public IdJsonOutput post_ProjectRemove(IdJsonInput model)
        {
            var id = _ravenProjectManager.Remove(model.Id);
            return new IdJsonOutput
            {
                Id = id
            };
        }
    }
}