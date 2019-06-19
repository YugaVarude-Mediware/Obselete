using Flux.Core;
using Flux.ORT2.Base;
using Flux.ORT2.StepHelpers.ObjectRepository.ORT;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Flux.ORT2.StepHelpers.PageObjects.ORT
{
    public class ORTCustomerSupportPage : ORTPageBase
    {
        #region Xpath declarations
        private readonly By txtFirstName = By.Id(ORTSmoke.txtFirstName_id);
        private readonly By txtLastName = By.Id(ORTSmoke.txtLastName_id);
        private readonly By txtEmailAddress = By.Id(ORTSmoke.txtEmailAddress_id);
        private readonly By txtMessage = By.Id(ORTSmoke.txtMessage_id);
        private readonly By txtSubject = By.Id(ORTSmoke.txtSubject_id);
        private readonly By btnSupport = By.XPath(ORTSmoke.btnSupport_XP);
        private readonly By alertOnSupportRequest = By.XPath(ORTSmoke.alertSupport_XP);
        #endregion

        #region Page Object Methods
        public void AddSupportFormDetails()
        {
            Waits.WaitForElementToBePresent(txtFirstName, WaitType.Large);
            Waits.WaitForElementToBePresent(txtLastName, WaitType.Large);
            Waits.WaitForElementToBePresent(txtEmailAddress, WaitType.Large);
            Waits.WaitForElementToBePresent(txtMessage, WaitType.Large);
            Waits.WaitForElementToBePresent(txtSubject, WaitType.Large);
            Actions.Clear(txtFirstName);
            Actions.Clear(txtLastName);
            Actions.Clear(txtEmailAddress);
            Actions.Clear(txtSubject);
            Actions.Clear(txtMessage);
            Actions.SendKeys(txtFirstName, ScenarioContext.Current["FirstName"].ToString());
            Actions.SendKeys(txtLastName, ScenarioContext.Current["LastName"].ToString());
            Actions.SendKeys(txtEmailAddress, ScenarioContext.Current["EmailAddress"].ToString());
            Actions.SendKeys(txtSubject, ScenarioContext.Current["Subject"].ToString());
            Actions.SendKeys(txtMessage, ScenarioContext.Current["Message"].ToString());
            StaticSleep(5000);
        }

        public void SendSupportRequest()
        {
            Actions.Click(btnSupport);
            StaticSleep(5000);
        }

        public void VerifySubmittedSupportReqest()
        {
            //capture the pop up message here to verify the request submitted successfully
            Verify.ElementIsPresent(alertOnSupportRequest);
            if (alertOnSupportRequest.ToString().Equals(ORTConstants.ORTConstants.alertOnSupportRequest))
            {
                Report.LogInfo("Request submitted");
                System.Console.WriteLine("Request submitted");
            }
        }

        #endregion
    }
}
