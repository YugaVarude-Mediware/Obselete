using Flux.ORT2.Base;
using Flux.Core;
using Flux.Web;
using OpenQA.Selenium;
using System;
using Flux.ORT2.CommonUtils;

//namespace SampleProject.StepHelpers.Page
namespace Flux.ORT2.StepHelpers.PageObjects
{
    public class LoginPage : ORTPageBase
    {

        #region Xpath declarations
        private readonly By txtUserName = By.Id("UserName");
        private readonly By txtPassword = By.Id("Password");
        private readonly By lnkSignin = By.LinkText("Sign In");
        private readonly By btnSignin = By.XPath("/html/body/div[2]/form/div[4]/div[2]/button");
        private readonly By lblLoggedInUser = By.XPath("//*[@id='navbarSupportedContent']/div/form/ul/li[1]/a");
        private readonly By btnSignOut = By.XPath("//*[@id='navbarSupportedContent']/div/form/ul/li[2]/button");
        #endregion

        #region Page Object Methods

        /// <summary>
        /// 
        /// </summary>
        public void LaunchApplication()
        {
            Actions.NavigateToUrl(WebEnvironment.AppSettings["AppUrl"]);
            Waits.WaitForPageLoad();
            Actions.DeleteAllCookies();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsAlreadyLoggedIn()
        {
            if (GlobalData.Get("LandingPageHandle") != String.Empty && GlobalData.Get("LandingPageHandle") != null)
            {
                Actions.SwitchToWindow(GlobalData.Get("LandingPageHandle"));
            }
            else
            {
                Actions.SwitchToFirstOrDefaultWindow();

            }
            bool loggedIn = false;
            if (Actions.IsDisplayed(lblLoggedInUser) && Actions.IsDisplayed(btnSignOut))
            {
                loggedIn = true;
            }

            return loggedIn;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns> NA </returns>
        public void Temp(string UserName, string Password)
        {
            int attempt = 0;
            bool loginSuccess = false;

            ReAttempt:
            try
            {
                Waits.WaitForElementToBeClickable(txtUserName, WaitType.Medium);
                Actions.SendKeys(txtUserName, UserName);
                Actions.SendKeys(txtPassword, Password);
                if (Actions.ClickLogin(btnSignin))
                {
                    Waits.WaitForPageLoad();
                    loginSuccess = true;
                }

            }
            catch (Exception ex)
            {
                if (IsAlreadyLoggedIn())
                {
                    loginSuccess = true;
                }
            }

            if (attempt <= 3 && !loginSuccess)
            {
                attempt++;
                LaunchApplication(); //multiple attempts
                goto ReAttempt;
            }


        }


        public void EnterLoginCredentials(string UserName, string Password)
        {
            try
            {
                Waits.WaitForElementToBeVisible(txtUserName, WaitType.Large);
                Actions.Clear(txtUserName);
                Actions.SendKeys(txtUserName, UserName);
                Actions.Clear(txtPassword);
                Actions.SendKeys(txtPassword, Password);
                //Waits.WaitForElementToBeClickable(btnSignin, WaitType.Large);
                //Actions.ExecuteJavascript("document.querySelector(\"[classname$='btn btn-primary btn-lg']\").click()");
                Actions.Click(btnSignin);
                //Synch up
                Actions.SwitchToDefaultFrame();
                Waits.WaitForElementToBeVisible(btnSignOut, WaitType.Large);
            }
            catch (Exception ex)
            {
                try
                {
                    Report.LogInfo("Exception occured during Login due to: " + ex.Message + "Trying to login again");
                    this.Logout();
                    Actions.Clear(txtUserName);
                    Actions.SendKeys(txtUserName, UserName);
                    Actions.Clear(txtPassword);
                    Actions.SendKeys(txtPassword, Password);
                    //Waits.WaitForElementToBeClickable(btnSignin, WaitType.Large);
                    Actions.Click(btnSignin);
                    //Actions.ExecuteJavascript("document.querySelector(\"[id$='CtrlLogin1_cmdLogin']\").click()");
                }
                catch (Exception exp)
                {
                    Report.LogError("Not able to login into iConnect Application");
                    throw new Exception(exp.Message.ToString() + Environment.NewLine + exp.StackTrace.ToString() + Environment.NewLine + exp.InnerException.ToString());
                }
            }

            Report.LogInfo("Logged into iConnect Application as user==>" + UserName);

        }

        public void ClicOnSignIn()
        {
            Actions.Click(lnkSignin);
        }

        public void Logout()
        {
        }

        #endregion

    }
}
