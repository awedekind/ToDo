using System;
using ToDo.Models;
using ToDo.Models.Input;
using ToDo.Models.Output;
using ToDo.Managers;

namespace ToDo.Controllers
{
    public class HomeController
    {
        private readonly IRavenManager<Duty> _ravenDutyManager;
        private readonly IRavenManager<Project> _ravenProjectManager;

        public HomeController(IRavenManager<Duty> ravenDutyManager, IRavenManager<Project> ravenProjectManager)
        {
            _ravenDutyManager = ravenDutyManager;
            _ravenProjectManager = ravenProjectManager;
        }

        /*Home Page*/
        public ProjectPageViewModel get_ProjectPage()
        {
            return new ProjectPageViewModel();
        }

        public DutyPageViewModel get_DutyPage_IdType_Id(DutyPageInput model)
        {
            var project = _ravenProjectManager.Load(model.GetId());
            return new DutyPageViewModel
            {
								Project = project
            };
        }
    }
}
