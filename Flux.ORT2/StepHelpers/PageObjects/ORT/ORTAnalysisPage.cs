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
    public class ORTAnalysisPage:ORTPageBase
    {
        #region Xpath declarations
        private readonly OpenQA.Selenium.By lnkAnalysis = By.Id(ORTSmoke.lnkAnalysis_id);
        private readonly By lnkTableA1 = By.LinkText(ORTSmoke.lnkTableA1_lt);
        private readonly By txtFiscalYear1 = By.Id(ORTSmoke.txtFiscalYear1_id);
        private readonly By btnRunReport = By.XPath(ORTSmoke.btnRunReport_XP);
        private readonly By lblTableA1CreatePage = By.XPath(ORTSmoke.lblTableA1CreatePage_XP);
        #endregion

        #region Page Object Methods
        public void ClickOnTableAReport()
        {
            //SelectTableAAnalysisReport(lnkTableA1);
            Waits.WaitForElementToBeVisible(lnkTableA1, WaitType.Large);
            Actions.Click(lnkTableA1);
        }

        public void UserIsOnCreatePageOfAnalysis()
        {
            Actions.SwitchToDefaultFrame();
            Waits.WaitForElementToBeVisible(lblTableA1CreatePage, WaitType.Large);
            String TableLable = Actions.GetText(lblTableA1CreatePage);
            try
            {
                if (TableLable.Equals("Table A-1 Selected Information by State and Region"))
                {
                    Report.LogInfo("User is on create page of Table report:" + TableLable);
                }
            }
            catch (Exception ex)
            {

            }

        }

        public void AddReportParameters()
        {
            Waits.WaitForElementToBePresent(txtFiscalYear1, WaitType.Large);
            StaticSleep(5000);
            Actions.Clear(txtFiscalYear1);
            Actions.SendKeys(txtFiscalYear1, ScenarioContext.Current["FiscalYear1"].ToString());
            StaticSleep(5000);
        }

        public void RunReport()
        {
            Actions.Click(btnRunReport);
            StaticSleep(5000);
        }

        public void OpenGeneratedReport()
        {

            //Actions.ExecuteJavascript("window.open();");
            //Actions.NavigateToUrl(("chrome://downloads/"));
            //Actions.ExecuteJavascript("document.querySelector(\"[id$='file-link']\").click()");
            // Actions.Click(lnkDownloadedReport);

        }
        #endregion
    }
}
