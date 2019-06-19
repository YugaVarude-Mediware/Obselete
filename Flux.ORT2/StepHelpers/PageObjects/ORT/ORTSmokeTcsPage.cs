using Flux.ORT2.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Flux.ORT2.StepHelpers.ObjectRepository.ORT;
using Flux.ORT2.CommonUtils;
using Flux.Core;
using Flux.ORT2.Enums;
using TechTalk.SpecFlow;
using System.Threading;
using Flux.Web;

namespace Flux.ORT2.StepHelpers.PageObjects.ORT
{
    public class ORTSmokeTcsPage : ORTPageBase
    {
        //private readonly Page pages;
        //public ORTSmokeTcsPage(Page pages)
        //{
        //    this.pages = pages;

        //}


        #region locaters
        private readonly By lnkAnalysis = By.Id(ORTSmoke.lnkAnalysis_id);
        private readonly By lnkTableA1 = By.LinkText(ORTSmoke.lnkTableA1_lt);
        private readonly By txtFiscalYear1 = By.Id(ORTSmoke.txtFiscalYear1_id);
        private readonly By lnkCancel = By.LinkText(ORTSmoke.lnkCancel_lt);
        private readonly By btnRunReport = By.XPath(ORTSmoke.btnRunReport_XP);
        private readonly By lblTableA1CreatePage = By.XPath(ORTSmoke.lblTableA1CreatePage_XP);
        private readonly By lnkDownloadedReport = By.PartialLinkText("Table A-1");
        private readonly By lnkReport = By.Id(ORTSmoke.lnkReport_id);
        private readonly By btnNewReport = By.XPath(ORTSmoke.btnNewReport_XP);
        private readonly By txtComments = By.Id(ORTSmoke.txtComments_id);
        private readonly By bthSubmit = By.Id(ORTSmoke.bthSubmit_id);
        private readonly By lnkCustomerSupport = By.XPath(ORTSmoke.lnkCustomerSupport_XP);
        //private readonly By txtFirstName = By.Id(ORTSmoke.txtFirstName_id);
        //private readonly By txtLastName = By.Id(ORTSmoke.txtLastName_id);
        //private readonly By txtEmailAddress = By.Id(ORTSmoke.txtEmailAddress_id);
        //private readonly By txtMessage = By.Id(ORTSmoke.txtMessage_id);
        //private readonly By txtSubject = By.Id(ORTSmoke.txtSubject_id);
        //private readonly By btnSupport = By.XPath(ORTSmoke.btnSupport_XP);
        //private readonly By alertOnSupportRequest = By.XPath(ORTSmoke.alertSupport_XP);
        //private readonly By lnkClearFilters = By.Id(ORTSmoke.lnkClearFilters_id);
        private readonly By lnkReportStatusFilter = By.XPath(ORTSmoke.lnkReportStatusFilter_XP);
        private readonly By spanFilterOption = By.XPath(ORTSmoke.spanFilter_XP);
        private readonly By btnFilter = By.XPath(ORTSmoke.btnFilter_XP);
        //private readonly By ddlReportSource = By.Id(ORTSmoke.ddlReportSource_id);
        //private readonly By ddlFiscalYear = By.XPath(ORTSmoke.ddlFiscalYear_XP);
        //private readonly By ddlOMBDatabase = By.Id(ORTSmoke.ddlOMBDatabase_id);
        //private readonly By chkSelectProgram = By.Id(ORTSmoke.chkSelectProgram_id);
        //private readonly By txtAnnuesWorkHrFte = By.Id(ORTSmoke.txtAnnuesWorkHrFte_id);

        #endregion

        #region methods
        //User navigates to page Analysis
        //public void UserNavigatesToPage(string Menu)
        //{
        //    Actions.SwitchToDefaultFrame();
        //    Actions.Click(lnkAnalysis);
        //}

        //public void ClickOnTableAReport()
        //{
        //    //SelectTableAAnalysisReport(lnkTableA1);
        //    Waits.WaitForElementToBeVisible(lnkTableA1, WaitType.Large);
        //    Actions.Click(lnkTableA1);
        //}

        //public void UserIsOnCreatePageOfAnalysis()
        //{
        //    Actions.SwitchToDefaultFrame();
        //    Waits.WaitForElementToBeVisible(lblTableA1CreatePage, WaitType.Large);
        //    String TableLable = Actions.GetText(lblTableA1CreatePage);
        //    try
        //    {
        //        if (TableLable.Equals("Table A-1 Selected Information by State and Region"))
        //        {
        //            Report.LogInfo("User is on create page of Table report:" + TableLable);
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }

        //}

        //public void AddReportParameters()
        //{
        //    Waits.WaitForElementToBePresent(txtFiscalYear1, WaitType.Large);
        //    StaticSleep(5000);
        //    Actions.Clear(txtFiscalYear1);
        //    Actions.SendKeys(txtFiscalYear1, ScenarioContext.Current["FiscalYear1"].ToString());
        //    StaticSleep(5000);
        //}

        //public void RunReport()
        //{
        //    Actions.Click(btnRunReport);
        //    StaticSleep(5000);
        //}

        //public void OpenGeneratedReport()
        //{

        //    //Actions.ExecuteJavascript("window.open();");
        //    //Actions.NavigateToUrl(("chrome://downloads/"));
        //    //Actions.ExecuteJavascript("document.querySelector(\"[id$='file-link']\").click()");
        //    // Actions.Click(lnkDownloadedReport);

        //}

        //public void AddSupportFormDetails()
        //{
        //    Waits.WaitForElementToBePresent(txtFirstName, WaitType.Large);
        //    Waits.WaitForElementToBePresent(txtLastName, WaitType.Large);
        //    Waits.WaitForElementToBePresent(txtEmailAddress, WaitType.Large);
        //    Waits.WaitForElementToBePresent(txtMessage, WaitType.Large);
        //    Waits.WaitForElementToBePresent(txtSubject, WaitType.Large);
        //    Actions.Clear(txtFirstName);
        //    Actions.Clear(txtLastName);
        //    Actions.Clear(txtEmailAddress);
        //    Actions.Clear(txtSubject);
        //    Actions.Clear(txtMessage);
        //    Actions.SendKeys(txtFirstName, ScenarioContext.Current["FirstName"].ToString());
        //    Actions.SendKeys(txtLastName, ScenarioContext.Current["LastName"].ToString());
        //    Actions.SendKeys(txtEmailAddress, ScenarioContext.Current["EmailAddress"].ToString());
        //    Actions.SendKeys(txtSubject, ScenarioContext.Current["Subject"].ToString());
        //    Actions.SendKeys(txtMessage, ScenarioContext.Current["Message"].ToString());
        //    StaticSleep(5000);
        //}

        //public void SendSupportRequest()
        //{
        //    Actions.Click(btnSupport);
        //    StaticSleep(5000);
        //}

        //public void ClickOnNewReport()
        //{
        //    Actions.Click(btnNewReport);
        //    StaticSleep(5000);
        //}

        //public void EnterReportDetails()
        //{
        //    Waits.WaitForElementToBePresent(txtComments, WaitType.Large);
        //    StaticSleep(5000);
        //    Actions.Clear(txtComments);
        //    Actions.SendKeys(txtComments, ScenarioContext.Current["Comments"].ToString());
        //    StaticSleep(5000);
        //}

        //public void SaveReportDetails()
        //{
        //    Actions.Click(bthSubmit);
        //    StaticSleep(5000);
        //}

        //public void EnterOMBDetailsToCreateReport()
        //{
        //    SelectDataByText(ddlReportSource, ScenarioContext.Current["ReportSource"].ToString());
        //    //SelectDataByValue(ddlFiscalYear, "2016");
        //    EnterDataInInputBox(ddlFiscalYear, ScenarioContext.Current["FiscalYear"].ToString());
        //    SelectDataByText(ddlOMBDatabase, ScenarioContext.Current["OmbudsManagerDatabase"].ToString());
        //    Verify.ElementIsPresent(chkSelectProgram);
        //    Waits.WaitForElementToBeClickable(chkSelectProgram, WaitType.Medium);
        //    Actions.Click(chkSelectProgram);
        //    Verify.ElementIsPresent(chkSelectProgram);
        //    EnterDataInInputBox(txtAnnuesWorkHrFte, ScenarioContext.Current["AnnualWorkHoursperFTE"].ToString());
        //    EnterDataInInputBox(txtComments, ScenarioContext.Current["Comments"].ToString());
        //    //Actions.SendKeys(txtComments, ScenarioContext.Current["Comments"].ToString());
        //    StaticSleep(5000);
        //}

        ////For selecting report source and fiscal year
        //public void SelectDataByText(By webElement, string value)
        //{
        //    Verify.ElementIsPresent(webElement);
        //    Waits.WaitForElementToBeClickable(webElement, WaitType.Medium);
        //    // Actions.Click(webElement);
        //    Actions.SelectByVisibleText(webElement, value);
        //    StaticSleep(5000);
        //}

        //public void EnterDataInInputBox(By webElement, string value)
        //{
        //    Verify.ElementIsPresent(webElement);
        //    Waits.WaitForElementToBeClickable(webElement, WaitType.Medium);
        //    Actions.Clear(webElement);
        //    StaticSleep(3000);
        //    Actions.SendKeys(webElement, value);
        //    StaticSleep(3000);
        //}

        //public void ClearAppliedFilterOfReportGrid()
        //{
        //    try
        //    {
        //        Waits.WaitForElementToBePresent(txtComments, WaitType.Large);
        //        Verify.ElementIsPresent(lnkClearFilters);
        //        Actions.Click(lnkClearFilters);
        //    }
        //    catch (Exception ex)
        //    {
        //        //Report.LogInfo("no filter is applied");
        //    }
        //}

        //public void VerifyReportIsCreated()
        //{
        //    string CurrentUrl = Actions.GetCurrentUrl();
        //    try
        //    {
        //        if (CurrentUrl.Contains("Part1"))
        //        {
        //            Report.LogInfo("User is on Part1 report");
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}

        public ORTMenu GetMenuNames(string menu)
        {
            foreach (ORTMenu mc in Enum.GetValues(typeof(ORTMenu)))
                if (mc.ToString() == menu)
                    return mc;

            return ORTMenu.Default;
        }

        public ReportStatus GetReportStatus(string reportStatus)
        {
            foreach (ReportStatus mc in Enum.GetValues(typeof(ReportStatus)))
                if (mc.ToString() == reportStatus)
                    return mc;


            return ReportStatus.Default;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="menuName"></param>
        public void ClickMenu(ORTMenu menuName)
        {

            switch (menuName)
            {
                case ORTMenu.Analysis:
                    {
                        Actions.Click(lnkAnalysis);
                        Waits.WaitForPageLoad();
                        break;
                    }

                case ORTMenu.ContactSupport:
                    {
                        Actions.SwitchToDefaultFrame();
                        Actions.Click(lnkCustomerSupport);
                        Waits.WaitForPageLoad();
                        break;
                    }
                case ORTMenu.Reports:
                    {
                        Actions.SwitchToDefaultFrame();
                        Actions.Click(lnkReport);
                        Waits.WaitForPageLoad();
                        break;
                    }

                default:
                    {

                        Log.Error("No valid menu found");
                        break;
                    }

            }
        }

        public void VerifyPageIsOpenSuccessfully(ORTMenu menuName)
        {
            switch (menuName)
            {
                case ORTMenu.Analysis:
                    {
                        Verify.ElementIsPresent(lnkAnalysis);
                        Actions.Click(lnkAnalysis);
                        Waits.WaitForElementToBeClickable(lnkAnalysis, WaitType.Medium);
                        Verify.ElementIsPresent(lnkAnalysis);
                        Verify.ExactTextInElementIs(lnkAnalysis, ORTConstants.ORTConstants.MenuAnalysis);
                        break;
                    }

                case ORTMenu.ContactSupport:
                    {
                        Verify.ElementIsPresent(lnkCustomerSupport);
                        Actions.Click(lnkCustomerSupport);
                        Waits.WaitForElementToBeClickable(lnkCustomerSupport, WaitType.Medium);
                        Verify.ElementIsPresent(lnkCustomerSupport);
                        Verify.ExactTextInElementIs(lnkCustomerSupport, ORTConstants.ORTConstants.MenuContactSupport);
                        break;
                    }

                case ORTMenu.Reports:
                    {
                        Verify.ElementIsPresent(lnkReport);
                        Actions.Click(lnkReport);
                        Waits.WaitForElementToBeClickable(lnkReport, WaitType.Medium);
                        Verify.ElementIsPresent(lnkReport);
                        Verify.ExactTextInElementIs(lnkReport, ORTConstants.ORTConstants.MenuReports);
                        break;
                    }

            }
        }

        //public void VerifySubmittedSupportReqest()
        //{
        //    //capture the pop up message here to verify the request submitted successfully
        //    Verify.ElementIsPresent(alertOnSupportRequest);
        //    if (alertOnSupportRequest.ToString().Equals(ORTConstants.ORTConstants.alertOnSupportRequest))
        //    {
        //        Report.LogInfo("Request submitted");
        //        System.Console.WriteLine("Request submitted");
        //    }
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="status"></param>
        public void SelectReportSourceFromFilter(ReportStatus status)
        {
            switch (status)
            {
                case ReportStatus.Certified:
                    {
                        Actions.Click(lnkAnalysis);
                        Waits.WaitForPageLoad();
                        break;                       
                    }

                case ReportStatus.InProgress:
                    {
                        Verify.ElementIsPresent(lnkCustomerSupport);
                        Actions.Click(lnkCustomerSupport);
                        Waits.WaitForElementToBeClickable(lnkCustomerSupport, WaitType.Medium);
                        Verify.ElementIsPresent(lnkCustomerSupport);
                        Verify.ExactTextInElementIs(lnkCustomerSupport, ORTConstants.ORTConstants.MenuContactSupport);
                        break;
                    }

                case ReportStatus.Locked:
                    {
                        Verify.ElementIsPresent(lnkReport);
                        Actions.Click(lnkReport);
                        Waits.WaitForElementToBeClickable(lnkReport, WaitType.Medium);
                        Verify.ElementIsPresent(lnkReport);
                        Verify.ExactTextInElementIs(lnkReport, ORTConstants.ORTConstants.MenuReports);
                        break;
                    }

                case ReportStatus.Verified:
                    {
                        Verify.ElementIsPresent(lnkReport);
                        Actions.Click(lnkReport);
                        Waits.WaitForElementToBeClickable(lnkReport, WaitType.Medium);
                        Verify.ElementIsPresent(lnkReport);
                        Verify.ExactTextInElementIs(lnkReport, ORTConstants.ORTConstants.MenuReports);
                        break;
                    }
            }
        }
        #endregion

    }
}

