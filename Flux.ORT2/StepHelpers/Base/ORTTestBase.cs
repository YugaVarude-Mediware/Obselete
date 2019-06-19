using Flux.Core;
using Flux.Web;
using OpenQA.Selenium;
//using SampleProject.StepHelpers.Page;
using System;
using TechTalk.SpecFlow;

namespace Flux.ORT2.Base
{
    [Binding]
    public class ORTTestBase : BddTestBase
    {
        /// <summary>
        /// This method runs once before all feature and initializes the browser instance
        /// </summary>
        [BeforeScenario]
        public static void ORTOneTimeSetup()
        {
            string browserName = string.Empty;

            try

            {
                browserName = WebEnvironment.AppSettings["BrowserType"].ToLower();
                BddTestBase.Environment.InitializeDriver(browserName);

                //GlobalData.Set("LandingPageHandle", bddHooks.Environment.Driver.CurrentWindowHandle);


            }

            catch (Exception e)

            {

                CustomExceptionHandler.CustomException(e, "Error occurred while trying to launch '" + browserName + "'.");

            }
        }


    }
}
