using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flux.Web;
using OpenQA.Selenium;
using Flux.ORT2.Base;
using Flux.ORT2.Enums;
using Flux.ORT2.StepHelpers.ObjectRepository.ORT;
using Flux.ORT2.ORTConstants;
using Flux.Core;
using Flux.ORT2.CommonUtils;

namespace Flux.ORT2.StepHelpers.CommonPageFunctions
{
    public class ORTCommonFunctionsForAnalysis : ORTPageBase
    {
        #region locaters
        private readonly By lnkAnalysis = By.Id(ORTSmoke.lnkAnalysis_id);
        private readonly By lnkReport = By.TagName(ORTSmoke.lnkReport_id);
        private readonly By lnkCustomerSupport = By.TagName(ORTSmoke.lnkCustomerSupport_XP);
        #endregion

        //public ORTCommonFunctionsForAnalysis(WebEnvironment testEnvironment)
        //{
        //    TestEnvironment = testEnvironment;
        //    Waits = new WebWaits(testEnvironment);
        //    Actions = new WebActions(testEnvironment);
        //}

        private WebWaits Waits { get; set; }

        private WebActions Actions { get; set; }

        private WebEnvironment TestEnvironment { get; set; }

        public void SwitchToCustomerSupportPage() => Actions.SwitchToWindowWithElement(lnkCustomerSupport);

        //ORT Specific: Select Table A Reports
        public void SelectTableAAnalysisReport(By locator)
        {
            Actions.Click(locator);
        }

        //public ORTMenu GetMenuNames(string menu)
        //{
        //    foreach (ORTMenu mc in Enum.GetValues(typeof(ORTMenu)))
        //        if (mc.ToString() == menu)
        //            return mc;


        //    return ORTMenu.Default;
        //}


        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="menuName"></param>
        //public void ClickMenu(ORTMenu menuName)
        //{

        //    switch (menuName)
        //    {
        //        case ORTMenu.Analysis:
        //            {
        //                Actions.Click(lnkAnalysis);
        //                Waits.WaitForPageLoad();
        //                break;
        //            }

        //        case ORTMenu.ContactSupport:
        //            {
        //                Actions.Click(lnkCustomerSupport);
        //                Waits.WaitForPageLoad();
        //                break;
        //            }
        //        case ORTMenu.Reports:
        //            {
        //                Actions.Click(lnkReport);
        //                Waits.WaitForPageLoad();
        //                break;
        //            }

        //        default:
        //            {

        //                Log.Error("No valid menu found");
        //                break;
        //            }

        //    }
        //}

        //public void VerifyPageIsOpenSuccessfully(ORTMenu menuName)
        //{
        //    switch (menuName)
        //    {
        //        case ORTMenu.Analysis:
        //            {
        //                Verify.ElementIsPresent(lnkAnalysis);
        //                Actions.Click(lnkAnalysis);
        //                Waits.WaitForElementToBeClickable(lnkAnalysis, WaitType.Medium);
        //                Verify.ElementIsPresent(lnkAnalysis);
        //                Verify.ExactTextInElementIs(lnkAnalysis, ORTConstants.ORTConstants.MenuAnalysis);
        //                break;
        //            }

        //        case ORTMenu.ContactSupport:
        //            {
        //                Verify.ElementIsPresent(lnkCustomerSupport);
        //                Actions.Click(lnkCustomerSupport);
        //                Waits.WaitForElementToBeClickable(lnkCustomerSupport, WaitType.Medium);
        //                Verify.ElementIsPresent(lnkCustomerSupport);
        //                Verify.ExactTextInElementIs(lnkCustomerSupport, ORTConstants.ORTConstants.MenuContactSupport);
        //                break;
        //            }

        //        case ORTMenu.Reports:
        //            {
        //                Verify.ElementIsPresent(lnkReport);
        //                Actions.Click(lnkReport);
        //                Waits.WaitForElementToBeClickable(lnkReport, WaitType.Medium);
        //                Verify.ElementIsPresent(lnkReport);
        //                Verify.ExactTextInElementIs(lnkReport, ORTConstants.ORTConstants.MenuReports);
        //                break;
        //            }

        //    }
        //}

    }
}

