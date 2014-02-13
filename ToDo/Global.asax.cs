using System;
using System.Web;
using FubuMVC.Core;
using FubuMVC.StructureMap;
using StructureMap;
using FubuPersistence.RavenDb;
using Raven.Client;
using Raven.Client.Document;
using ToDo.Models;
using ToDo.Registries;
using ToDo.Managers;

namespace ToDo
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            var store = new DocumentStore
            {
                ConnectionStringName = "RavenDBConnection",
            };
            //store.Conventions.FindIdentityProperty = (prop => prop.DeclaringType.Name + "ID" == prop.Name);
            
            
            store.Initialize();

            FubuApplication.For<ConfigureFubuMVC>()
                .StructureMap(new Container(x =>
                {
                    x.ConnectToRavenDb<RavenDbSettings>();
                    x.For<IDocumentSession>().Use(store.OpenSession);
                    x.For<IDocumentStore>().Use(store);
                    x.For<IRavenManager<Task>>().Use<RavenManager<Task>>();
                    x.For<IRavenManager<Project>>().Use<RavenManager<Project>>();
                }))
                .Bootstrap();
        }
    }
}