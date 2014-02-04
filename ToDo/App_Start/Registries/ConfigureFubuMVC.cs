using FubuMVC.Core;
using FubuMVC.Core.Registration;
using FubuMVC.Core.Runtime;
using FubuMVC.Core.UI;
using Raven.Client;
using Raven.Client.Document;
using StructureMap.Configuration.DSL;
using ToDo.Controllers;
using System.Collections.Generic;
using System.Linq;
using FubuMVC.Core.Behaviors;
using System.Transactions;
using FubuMVC.Core.Registration.Nodes;
using ToDo.JsonWriter;

namespace ToDo.Registries
{
    public class ConfigureFubuMVC : FubuRegistry
    {
        public ConfigureFubuMVC()
        {
            Actions.IncludeClassesSuffixedWithController();
            Routes.HomeIs<HomeController>(x => x.get_Index());
            Policies.Add<TransactionPolicy>();
            Services(x => x.ReplaceService<IJsonWriter, JsonWriterStrEnum>());
        }
    }

    public class TransactionPolicy : IConfigurationAction
    {
        public void Configure(BehaviorGraph graph)
        {
            graph.Actions()
                .Where(x => x.HandlerType == typeof(HomeController))
								.Each(x => x.AddBefore(new Wrapper(typeof(TransactionBehavior))));
        }
    }

    public class TransactionBehavior : IActionBehavior
    {
        public IActionBehavior InnerBehavior { get; set;}

        public void Invoke()
        {
            using (var transaction = new TransactionScope())
            {
                InnerBehavior.Invoke();
                transaction.Complete();
            }
        }

        public void InvokePartial()
        {
        }
    }



    //public class TestHtmlConventions : HtmlConventionRegistry
    //{
    //    public TestHtmlConventions()
    //    {
    //        Editors.If()
    //    }
    //}
}