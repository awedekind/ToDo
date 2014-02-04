using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FubuMVC.Core;
using FubuMVC.StructureMap;
using StructureMap;
using FubuPersistence.RavenDb;
using Raven.Client;
using Raven.Client.Document;
using ToDo.Registries;
using ToDo.Controllers;
using ToDo.Managers;

namespace ToDo
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            var store = new DocumentStore
            {
                ConnectionStringName = "RavenDBConnection"
            }.Initialize();
            //For<IDocumentSession>().Use(() => docStore.OpenSession());
            //For<IDocumentStore>().Singleton().Use(docStore);
            //For<RavenController>().Use(new RavenController(docStore.OpenSession()));

            FubuApplication.For<ConfigureFubuMVC>()
                .StructureMap(new Container(x =>
                {
                    x.ConnectToRavenDb<RavenDbSettings>();

                    //x.Scan(i =>
                    //        {
                    //            //Registers all StructureMap registries
                    //            i.TheCallingAssembly();
                    //            PackageRegistry.PackageAssemblies.Each(i.Assembly);
                    //            i.LookForRegistries();
                    //        });
                    //x.ForRequestedType<IDocumentSession>()
                    //    .TheDefault.IsThis(store.OpenSession());
                    x.For<IDocumentSession>().Use(store.OpenSession);
                    x.For<IDocumentStore>().Use(store);
                    x.For<IRavenManager>().Use<RavenManager>();
                }))
                .Bootstrap();
        }
    }
}