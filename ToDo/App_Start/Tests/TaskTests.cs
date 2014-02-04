using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NUnit.Framework;
using ToDo.Models;

namespace ToDo.App_Start.Tests
{
    [TestFixture]
    public class TaskTests
    {
        [Test]
        public void AssignStateFromString_ToDo()
        {
            var task = new Task("task", "task", "ToDo");
            Assert.AreEqual(State.ToDo, task.Status);
        }

        [Test]
        public void AssignStateFromString_Doing()
        {
            var task = new Task("task", "task", "Doing");
            Assert.AreEqual(State.Doing, task.Status);
        }

        [Test]
        public void AssignStateFromString_Done()
        {
            var task = new Task("task", "task", "Done");
            Assert.AreEqual(State.Done, task.Status);
        }

        [Test]
        public void AssignStateFromString_StringIsNotState()
        {
            var task = new Task("task", "task", "NotAState");
            Assert.AreEqual(State.ToDo, task.Status);
        }
    }
}