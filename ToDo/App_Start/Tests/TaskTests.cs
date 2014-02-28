using System;
using System.Collections.Generic;
using System.Diagnostics;
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
          var task = new Duty("task", "task", "ToDo");
          Assert.AreEqual(State.Todo, task.Status);
        }

      [Test]
        public void AssignStateFromString_Doing()
        {
          var task = new Duty("task", "task", "Doing");
          Assert.AreEqual(State.Doing, task.Status);
        }

      [Test]
        public void AssignStateFromString_Done()
        {
          var task = new Duty("task", "task", "Done");
          Assert.AreEqual(State.Done, task.Status);
        }

    public class foo
							{
          private class bar
						{
              public int harhar()
								 {
									  var har = Func<int, int>(x => x + 1);
                  return har(1) + 1;
              }
									}
      }

      [Test]
        public void AssignStateFromString_StringIsNotState()
        {
          var task = new Duty("task", "task", "NotAState");
          Assert.AreEqual(State.Todo, task.Status);
        }
      [Test]
        public void PlayZone(){
          var one = 1+2*3-4;
          Assert.AreEqual(3, one);
          Debug.WriteLine(one);
          var two = (1+2) *3-4; //Surround 1 & 2 with ()=
          Assert.AreEqual(5,two);
          Debug.WriteLine(two);
          var three = 2* (3+4) * (5+8); //surround 3&4 and 5&8 with ()
          Assert.AreEqual(182, three);
          Debug.WriteLine(three);

          //surround every third word with (|{|[|"|'

        }

    }
}
