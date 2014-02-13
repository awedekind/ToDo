using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Raven.Client;
using ToDo.Models;

namespace ToDo.Managers
{
    public class RavenManager<T> : IRavenManager<T> where T : Project
    {
        private readonly IDocumentSession _session;

        public RavenManager(IDocumentSession session)
        {
            _session = session;
        }

        public T Load(string id)
        {
            return _session.Load<T>(id);
        }

        public IList<T> LoadMany(string projectId)
        {
							return _session.Query<T>().Where(x => x.ProjectId == projectId).ToList();
        }

        public IList<T> LoadAll()
        {
            return _session.Query<T>().ToList();
        }

        public T Save(T project, string id)
        {
            if (id != null)
            {
                _session.Store(project, id);
            }
            else
            {
                _session.Store(project);
            }
            _session.SaveChanges();

            return project;
        }

        public string Remove(string id)
        {
            var item = Load(id);
            _session.Delete(item);
            _session.SaveChanges();
            return id;
        }
    }
}