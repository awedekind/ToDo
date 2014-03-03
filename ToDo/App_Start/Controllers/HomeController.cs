﻿using System;
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
//This file has changed for the sake of science!!
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
        public void amethod(){
          //This method was made to create a change, so a I can play with pushing a file using fugitive.vim
        }
    }
}
