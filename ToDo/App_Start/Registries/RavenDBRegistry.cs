//using Raven.Client;
//using Raven.Client.Document;
//using StructureMap.Configuration.DSL;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using ToDo.App_Start;

//namespace ToDo
//{
//    public class RavenDBRegistry : Registry
//    {
//        public RavenDBRegistry()
//        {
//            var docStore = new DocumentStore
//            {
//                ConnectionStringName = "RavenDBConnection"
//            }.Initialize();
//            //For<IDocumentSession>().Use(() => docStore.OpenSession());
//            //For<IDocumentStore>().Singleton().Use(docStore);
//            //For<RavenController>().Use(new RavenController(docStore.OpenSession()));

//        }
//    }
//}