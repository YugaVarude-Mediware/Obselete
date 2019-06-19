using System;
using TechTalk.SpecFlow;
using Flux.ORT2.Base;
using Flux.Core;
using Flux.Web;
using Flux.ORT2.Enums;
using OpenQA.Selenium;
//using Flux.ORT2.Common;
using Flux.ORT2.StepHelpers.PageObjects.ORT;
using Flux.ORT2.CommonUtils;

namespace Flux.ORT2.StepDefinitions.ORT
{
    [Binding]
    public class ORTSmokeTCsSteps : ORTTestBase
    {
        private readonly Page pages;

        public ORTSmokeTCsSteps(Page pages)
        {
            this.pages = pages;

        }

        [Given(@"User is on ORT landing Page")]
        public void GivenUserIsOnORTLandingPage()
        {
            //ScenarioContext.Current.Pending();
        }

        [Given(@"User navigates to page '(.*)'")]
        public void GivenUserNavigatesToPage(string menus)
        {
            var menu = CommonFunctions.GetEnumNameFromString<ORTMenu>(menus);            
            pages.ORTSmokeTcsPage.ClickMenu(menu);
            pages.ORTSmokeTcsPage.VerifyPageIsOpenSuccessfully(menu);
            System.Threading.Thread.Sleep(3000);
        }

        [Given(@"User Opens analysis report '(.*)'")]
        public void GivenUserOpensAnalysisReport(string p0)
        {
            pages.ORTAnalysisPage.ClickOnTableAReport();
            pages.ORTAnalysisPage.Waits.WaitForPageLoad();
        }

        [When(@"User navigates to Creation page of analysis report")]
        public void WhenUserNavigatesToCreationPageOfAnalysisReport()
        {
            pages.ORTAnalysisPage.UserIsOnCreatePageOfAnalysis();
        }

        [When(@"User enters following '(.*)'")]
        public void WhenUserEntersFollowing(string p, Table table)
        {
            TableExtensions.InitializeScenarioContext(table);
            pages.ORTAnalysisPage.AddReportParameters();
        }

        [When(@"User runs report")]
        public void WhenUserRunsReport()
        {
            pages.ORTAnalysisPage.RunReport();
        }

        [Then(@"Report should be generated in excel file")]
        public void ThenReportShouldBeGeneratedInExcelFile()
        {
            pages.ORTAnalysisPage.OpenGeneratedReport();
        }

        [When(@"User enters '(.*)' as follows")]
        public void WhenUserEntersAsFollows(string type, Table table)
        {
            ScenarioContext.Current["Type"] = type;
            TableExtensions.InitializeScenarioContext(table);
            pages.ORTCustomerSupportPage.AddSupportFormDetails();
        }

        [When(@"sends request to support")]
        public void WhenSendsRequestToSupport()
        {
            pages.ORTCustomerSupportPage.SendSupportRequest();
        }

        [Then(@"Request should be submitted successfully")]
        public void ThenRequestShouldBeSubmittedSuccessfully()
        {
            pages.ORTCustomerSupportPage.VerifySubmittedSupportReqest();
        }

        [Given(@"tries to access '(.*)'")]
        public void GivenTriesToAccess(string p0)
        {
            pages.ORTReportsPage.ClickOnNewReport();
            pages.ORTReportsPage.Waits.WaitForPageLoad();
        }

        //[When(@"User creates report with '(.*)'")]
        //public void WhenUserCreatesReportWith(string p0, Table table)
        //{
        //    TableExtensions.InitializeScenarioContext(table);
        //    pages.ORTSmokeTcsPage.EnterReportDetails();
        //    pages.ORTSmokeTcsPage.Waits.WaitForPageLoad();
        //}
        [When(@"User enters following '(.*)' to create blank report")]
        public void WhenUserEntersFollowingToCreateBlankReport(string p0, Table table)
        {
            TableExtensions.InitializeScenarioContext(table);
            pages.ORTReportsPage.EnterReportDetails();
            pages.ORTReportsPage.Waits.WaitForPageLoad();
        }


        [When(@"User saves report")]
        public void WhenUserSavesReport()
        {
            pages.ORTReportsPage.SaveReportDetails();
            pages.ORTReportsPage.Waits.WaitForPageLoad();
        }

        [Then(@"Report should be created")]
        public void ThenReportShouldBeCreated()
        {
            pages.ORTReportsPage.VerifyReportIsCreated();
            pages.ORTReportsPage.Waits.WaitForPageLoad();
        }

        [When(@"enter following '(.*)' to import report")]
        public void WhenEnterFollowingToImportReport(string type, Table table)
        {
            ScenarioContext.Current["Type"] = type;
            TableExtensions.InitializeScenarioContext(table);
            pages.ORTReportsPage.EnterOMBDetailsToCreateReport();
        }

        [When(@"User clears applied filter")]
        public void WhenUserClearsAppliedFilter()
        {
            pages.ORTReportsPage.ClearAppliedFilterOfReportGrid();
            pages.ORTReportsPage.Waits.WaitForPageLoad();
        }

        [When(@"User applies filter on Report Status column")]
        public void WhenUserAppliesFilterOnReportStatusColumn()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"User selects below '(.*)'")]
        public void WhenUserSelectsBelow(string p0, Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"User applies selected filter")]
        public void WhenUserAppliesSelectedFilter()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"Selected filter should get applied")]
        public void ThenSelectedFilterShouldGetApplied()
        {
            ScenarioContext.Current.Pending();
        }

    }
}
