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
    public class ORTReportsPage: ORTPageBase
    {
        #region Xpath declarations
        private readonly By lnkReport = By.Id(ORTSmoke.lnkReport_id);
        private readonly By btnNewReport = By.XPath(ORTSmoke.btnNewReport_XP);
        private readonly By txtComments = By.Id(ORTSmoke.txtComments_id);
        private readonly By bthSubmit = By.Id(ORTSmoke.bthSubmit_id);
        private readonly By lnkCustomerSupport = By.XPath(ORTSmoke.lnkCustomerSupport_XP);
        private readonly By ddlReportSource = By.Id(ORTSmoke.ddlReportSource_id);
        private readonly By ddlFiscalYear = By.XPath(ORTSmoke.ddlFiscalYear_XP);
        private readonly By ddlOMBDatabase = By.Id(ORTSmoke.ddlOMBDatabase_id);
        private readonly By chkSelectProgram = By.Id(ORTSmoke.chkSelectProgram_id);
        private readonly By txtAnnuesWorkHrFte = By.Id(ORTSmoke.txtAnnuesWorkHrFte_id);
        private readonly By lnkClearFilters = By.Id(ORTSmoke.lnkClearFilters_id);
        #endregion

        #region Page Object Methods
        public void ClickOnNewReport()
        {
            Actions.Click(btnNewReport);
            StaticSleep(5000);
        }

        public void EnterReportDetails()
        {
            Waits.WaitForElementToBePresent(txtComments, WaitType.Large);
            StaticSleep(5000);
            Actions.Clear(txtComments);
            Actions.SendKeys(txtComments, ScenarioContext.Current["Comments"].ToString());
            StaticSleep(5000);
        }

        public void SaveReportDetails()
        {
            Actions.Click(bthSubmit);
            StaticSleep(5000);
        }

        public void EnterOMBDetailsToCreateReport()
        {
            SelectDataByText(ddlReportSource, ScenarioContext.Current["ReportSource"].ToString());
            //SelectDataByValue(ddlFiscalYear, "2016");
            EnterDataInInputBox(ddlFiscalYear, ScenarioContext.Current["FiscalYear"].ToString());
            SelectDataByText(ddlOMBDatabase, ScenarioContext.Current["OmbudsManagerDatabase"].ToString());
            Verify.ElementIsPresent(chkSelectProgram);
            Waits.WaitForElementToBeClickable(chkSelectProgram, WaitType.Medium);
            Actions.Click(chkSelectProgram);
            Verify.ElementIsPresent(chkSelectProgram);
            EnterDataInInputBox(txtAnnuesWorkHrFte, ScenarioContext.Current["AnnualWorkHoursperFTE"].ToString());
            EnterDataInInputBox(txtComments, ScenarioContext.Current["Comments"].ToString());
            //Actions.SendKeys(txtComments, ScenarioContext.Current["Comments"].ToString());
            StaticSleep(5000);
        }

        //For selecting report source and fiscal year
        public void SelectDataByText(By webElement, string value)
        {
            Verify.ElementIsPresent(webElement);
            Waits.WaitForElementToBeClickable(webElement, WaitType.Medium);
            // Actions.Click(webElement);
            Actions.SelectByVisibleText(webElement, value);
            StaticSleep(5000);
        }

        public void EnterDataInInputBox(By webElement, string value)
        {
            Verify.ElementIsPresent(webElement);
            Waits.WaitForElementToBeClickable(webElement, WaitType.Medium);
            Actions.Clear(webElement);
            StaticSleep(3000);
            Actions.SendKeys(webElement, value);
            StaticSleep(3000);
        }

        public void ClearAppliedFilterOfReportGrid()
        {
            try
            {
                Waits.WaitForElementToBePresent(txtComments, WaitType.Large);
                Verify.ElementIsPresent(lnkClearFilters);
                Actions.Click(lnkClearFilters);
            }
            catch (Exception ex)
            {
                //Report.LogInfo("no filter is applied");
            }
        }

        public void VerifyReportIsCreated()
        {
            string CurrentUrl = Actions.GetCurrentUrl();
            try
            {
                if (CurrentUrl.Contains("Part1"))
                {
                    Report.LogInfo("User is on Part1 report");
                }
            }
            catch (Exception ex)
            {

            }
        }
        #endregion
    }
}
