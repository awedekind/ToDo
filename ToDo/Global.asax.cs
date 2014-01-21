using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using FubuMVC.Core;
using FubuMVC.StructureMap;
using StructureMap;
using Bottles;
using FubuPersistence.RavenDb;
using Raven.Client.Embedded;
using Raven.Client;
using Raven.Client.Document;
using ToDo.App_Start;
using ToDo.App_Start.Controllers;

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
                    var session = store.OpenSession();
                    x.For<IDocumentSession>().Use(session);
                    x.For<IDocumentStore>().Use(store);
                    RavenController controller = new RavenController(session);
                    x.For<IRavenController>().Use(controller);

                }))
                .Bootstrap();

            
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}