using Flux.ORT2.Base;
using Flux.ORT2.CommonUtils;
using Flux.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Flux.ORT2.StepDefinitions.Login
{
    [Binding]
    public class Login : ORTTestBase
    {

        private readonly Page pages;
        public Login(Page pages)
        {
            this.pages = pages;

        }


        [Given(@"User is logged In '(.*)'")]
        public void GivenUserIsLoggedIn(string p0)
        {

            if (!pages.LoginPage.IsAlreadyLoggedIn())
            {
                pages.LoginPage.LaunchApplication();
                pages.LoginPage.ClicOnSignIn();
                pages.LoginPage.EnterLoginCredentials(WebEnvironment.AppSettings["UserName"], WebEnvironment.AppSettings["Password"]);
            }
        }
    }
}
