using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NUnit.Framework;
using Rhino.Mocks;
using ToDo.Controllers;
using ToDo.Models.Input;
using ToDo.Models.Output;
using ToDo.Models;
using ToDo.Managers;

namespace ToDo.Tests
{
    [TestFixture]
    public class HomeEndpointTests
    {
        //DOC
        private IRavenManager _ravenMock;
        //SUT
        private HomeController _home;
        //Mock Data
        private IList<Task> defaultTasks;

        [SetUp]
        public void setup()
        {
            _ravenMock = MockRepository.GenerateMock<IRavenManager>();
            _home = new HomeController(_ravenMock);

            defaultTasks = new List<Task>
            {
                new Task("TaskOne", "The first task", "ToDo"),
                new Task("TaskTwo", "The second task.", "Doing")
            };
        }

        //[Test]
        //public void Get_IndexTest()
        //{
        //    _ravenMock.Expect(x => x.LoadAllTasks()).Return(defaultTasks);

        //    TaskPageViewModel generatedPage = _home.get_Index();
        //    var expectedPage = new TaskPageViewModel(defaultTasks);

        //    Assert.AreEqual(expectedPage.Tasks, generatedPage.Tasks);
        //}

        //        [Test]
        //public void UpdateTask_Test()
        //{
						
        //}

        //[Test]
        //public void NewTask_Test()
        //{
        //    var input = new UrlSaveUpdateInputModel
        //    {
        //        Name = "Task Three",
        //        Description = "The third task"
        //    };

        //    var task = new Task("Task Three", "The third task", "ToDo");
        //    defaultTasks.Add(task);
        //    _ravenMock.Expect(x => x.SaveTask(task));
        //    _ravenMock.Expect(x => x.LoadAllTasks()).Return(defaultTasks);

        //    var viewExpected = new TaskPageViewModel(defaultTasks);
        //    TaskPageViewModel viewActual = _home.put_NewTask_Name_Description(input);

        //    Assert.AreEqual(viewExpected.Tasks, viewActual.Tasks);
        //}

        //[Test]
        //public void GetId_Test()
        //{
        //    var input = new UrlIdInputModel
        //    {
        //        IdType = "type",
        //        Id = "3"
        //    };

        //    Assert.AreEqual("type/3", input.GetId());
        //}
    }
}