using Flux.ORT2.Base;
using Flux.ORT2;
using Flux.Web;
using Flux.ORT2.StepHelpers.CommonPageFunctions;
using Flux.ORT2.StepHelpers.PageObjects;
using Flux.ORT2.StepHelpers.PageObjects.ORT;

namespace Flux.ORT2.CommonUtils
{
    public class Page : ORTTestBase
    {

        /// <summary>
        /// Generic method to return page objects
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GetPage<T>() where T : Web.WebPageBase, new()
        {
            // bddTestBase = new BddTestBase();

            var page = BddTestBase.Application.NewPage<T>();
            return page;
        }

        public LoginPage LoginPage
        {
            get => Application.NewPage<LoginPage>();
        }

        public ORTSmokeTcsPage ORTSmokeTcsPage
        {
            get => Application.NewPage<ORTSmokeTcsPage>();
        }

        public ORTAnalysisPage ORTAnalysisPage
        {
            get => Application.NewPage<ORTAnalysisPage>();
        }
     
        public ORTCustomerSupportPage ORTCustomerSupportPage
        {
            get => Application.NewPage<ORTCustomerSupportPage>();
        }

        public ORTReportsPage ORTReportsPage
        {
            get => Application.NewPage<ORTReportsPage>();
        }        
    }
}
