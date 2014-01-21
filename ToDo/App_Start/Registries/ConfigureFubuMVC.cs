using FubuMVC.Core;
using FubuMVC.Core.UI;
using Raven.Client;
using Raven.Client.Document;
using StructureMap.Configuration.DSL;
using ToDo.App_Start.Controllers;

namespace ToDo
{
    public class ConfigureFubuMVC : FubuRegistry
    {
        public ConfigureFubuMVC()
        {
            //Actions.IncludeClassesSuffixedWithController();
            Routes.HomeIs<HomeEndpoint>(x => x.get_Index());
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