using System.Collections.Generic;
using ToDo.Models;
using ToDo.Models.Input;
using ToDo.Models.Output;
using ToDo.Managers;

namespace ToDo.Controllers
{
  //This is the third file to change
    public class ProjectController
    {
        private readonly IRavenManager<Duty> _ravenDutyManager;
        private readonly IRavenManager<Project> _ravenProjectManager;

        public ProjectController(IRavenManager<Duty> ravenDutyManager, IRavenManager<Project> ravenProjectManager)
        {
            _ravenDutyManager = ravenDutyManager;
            _ravenProjectManager = ravenProjectManager;
        }

        /*Project Endpoints*/
        public ListJsonResponse<Project> get_Projects()
        {
            return new ListJsonResponse<Project>
            {
                Items = _ravenProjectManager.LoadAll()
            };
        }

        public ListJsonResponse<Duty> post_Project_Duties(IdJsonInput model)
        {

            //var duties = _ravenDutyManager.LoadMany(model.Id);

            //return new ListJsonResponse<Duty>
            //{
            //    Items = duties
            //};
            return null;
        }

        public ItemJsonResponse<Project> post_Project_Duty_New(ProjectDutyInput model)
        {
            var project = new Project()
            {
                Name = model.Name,
                Description = model.Description,
								Id = model.Id,
                Duties = model.Duties
            };
            var duty = new Duty()
            {
                Name = model.DutyName,
                Description = model.DutyDescription
            };
            return null;
        }

        public class ProjectDutyInput
        {
						//Project
            public string Id { get; set; }
            public string Description { get; set; }
            public string Name { get; set; }
            public IList<Duty> Duties { get; set; }
						//Duty
            public string DutyDescription { get; set; }
            public string DutyName { get; set; }
        }

        public class ProjectDutyUpdateInput : ProjectDutyInput
        {
           //Duty
            public string DutyId { get; set; }
            public State Statues { get; set; }
        }

        public void post_Project_Duty_Update()
        {
						//Project
						//Duty Id, Name, Description, Status
            
        }

        public void post_Project_Duty_Remove()
        {
						//Project
						//Duty Id
        }

        public ItemJsonResponse<Project> post_Project_New(SaveJsonInput model)
        {
            var project = new Project
            {
                Name = model.Name,
                Description = model.Description,
								Duties = new List<Duty>()
            };

						project.Duties.Add(new Duty
						{
						    Name = "Hardcoded Duty",
								Description = "A duty to quickly see what the db looks like.",
								Status = State.Todo
						});
            project = _ravenProjectManager.Save(project, null);

            return new ItemJsonResponse<Project>
            {
                Item = project
            };
        }

        public ItemJsonResponse<Project> post_Project_Update(UpdateProjectJsonInput model)
        {
            var project = new Project
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
								Duties = model.Duties
            };

            _ravenProjectManager.Save(project, project.Id);

            return new ItemJsonResponse<Project>
            {
                Item = project
            };
        }

        public IdJsonOutput post_Project_Remove(IdJsonInput model)
        {
            var id = _ravenProjectManager.Remove(model.Id);
            return new IdJsonOutput
            {
                Id = id
            };
        }
    }
}
