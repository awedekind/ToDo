using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToDo.Models;


namespace ToDo.Managers
{
    public interface IRavenManager<T> where T : Project
    {
        IList<T> LoadAll();
        T Load(string id);
        T Save(T obj, string id);
        IList<T> LoadMany (string projectId);
        string Remove(string id);
    }
}
