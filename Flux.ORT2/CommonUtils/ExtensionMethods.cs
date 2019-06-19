using Flux.ORT2.StepHelpers.ObjectRepository;
using Flux.Core;
using Flux.Web;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flux.ORT2.Enums;

namespace Flux.ORT2.CommonUtils
{
    public static class ExtensionMethods
    {

        /// <summary>
        /// This click element is an extension to web action, it tried to supress the tiem out exception in login cases
        /// </summary>
        /// <param name="webActions"></param>
        /// <param name="locater"></param>
        public static bool ClickLogin(this WebActions webActions, By locater)
        {

            try
            {
                webActions.Click(locater);
                System.Threading.Thread.Sleep(3000);
                return true;

            }
            catch (TimeoutException ex)
            {
                return false;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        /// <summary>
        /// This is generic method for click on Menu items
        /// </summary>
        /// <param name="webActions"></param>
        /// <param name="MainMenu"></param>
        /// <param name="SubMenu"></param>
        //public static void ClickMenu(this WebActions webActions, By MainMenu, By SubMenu)
        //{
        //    System.Threading.Thread.Sleep(2000);
        //    webActions.Click(MainMenu);
        //    System.Threading.Thread.Sleep(2000);
        //    webActions.Click(SubMenu);
        //}

        /// <summary>
        /// This is an common extension method to wait for the APS update progess image to disappear
        /// </summary>
        /// <param name="webActions"></param>
        /// <param name="Locater">By locater for the update image</param>
        public static void WaitForUpdateProgressBar(this WebActions webActions, By Locater)
        {

            int counter = 0;
            bool Invisible = false;
            retry:

            if (webActions.IsDisplayed(Locater))
            {
                counter++;
                System.Threading.Thread.Sleep(2000);
                Invisible = false;
            }
            else
            {
                Invisible = true;

            }


            if (counter < 30 && !Invisible)
            {
                goto retry;
            }
        }

        /// <summary>
        /// This extension method will close all the workflow window, better to place this at the end of script execution
        /// </summary>
        /// <param name="webActions"></param>
        //public static void CloseAllWorkFlowWindows(this WebActions webActions)
        //{
        //    retry:
        //    IReadOnlyCollection<string> allHandles = webActions.GetWindowHandles();
        //    try
        //    {
        //        foreach (string handle in allHandles)
        //        {
        //            webActions.SwitchToWindow(handle);
        //            if (webActions.GetWindowTitle().Contains(CommonObjects.wndWorkFlowTitle))
        //            {
        //                webActions.CloseBrowser();
        //            }
        //        }

        //        webActions.SwitchToFirstOrDefaultWindow();
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Threading.Thread.Sleep(3000);
        //        goto retry;
        //    }
        //}

        /// <summary>
        /// Generic extension method to get the x y co ordinates of the web element
        /// </summary>
        /// <param name="webActions"></param>
        /// <param name="ByLocater"></param>
        /// <returns></returns>
        public static Tuple<int, int> GetElementXYCoordinates(this WebActions webActions, By ByLocater)
        {
            int x = webActions.FindElement(ByLocater).Location.X;
            int y = webActions.FindElement(ByLocater).Location.Y;

            return Tuple.Create(x, y);
        }

        /// <summary>
        /// Dynamic switching with the help of window handles and element
        /// </summary>
        /// <param name="webActions"></param>
        /// <param name="locater"></param>
        public static void SwitchToWindowWithElement(this WebActions webActions, By locater)
        {
            bool found = false;
            int counter = 0;
            reAttempt:

            IReadOnlyCollection<string> allHandles = webActions.GetWindowHandles();

            foreach (string handle in allHandles)
            {
                webActions.SwitchToWindow(handle);
                if (webActions.IsElementPresent(locater))
                {
                    found = true;
                    break;
                }
            }

            if (!found && counter < 3)
            {
                goto reAttempt;
            }
        }

        ////ORT Specific: Select Table Reports
        //public static void SelectAnalysisReport(this WebActions webActions, By locator)
        //{
        //    webActions.Click(locator);
        //}

        #region Synchronization Extensions

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wait"></param>
        /// <param name="waitType"></param>
        public static void StaticSleep(this Waits wait, WaitType waitType) => System.Threading.Thread.Sleep((Int32)waitType * 1000);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="timeout"></param>
        public static void WaitUntilProgressBlockDisappears(this Waits waits, int timeout)
        {

            //try
            //{

            //    var wait = new WebDriverWait(BddHooks.Environment.Driver, new TimeSpan(0, 0, 0,timeout));
            //    wait.IgnoreExceptionTypes(new Type[] { new StaleElementReferenceException().GetType() });

            //    wait.Until<Boolean>(driver =>
            //    {
            //        if (!driver.FindElement(By.CssSelector("#ctrlTopMenu1__updateProgress")).GetAttribute("style").Contains("display: block"))
            //        {
            //            Console.WriteLine("Loading message disappeared");
            //            return true;
            //        }
            //        else
            //        {
            //            System.Threading.Thread.Sleep(1000);
            //            return false;
            //        }
            //    });
            //}
            //catch (Exception) { Console.WriteLine("Waiting for 5 seconds for loading message to disappear"); }

            //System.Threading.Thread.Sleep(5000);
        }

        #endregion

        #region WebTables Extensions

        /// <summary>
        /// generic method to search and match string and click on any table row
        /// </summary>
        /// <param name="webActions"></param>
        /// <param name="tableLocater"></param>
        /// <param name="searchCriteria"></param>
        public static void ClickTableRowWithSearchCriteria(this WebActions webActions, By tableLocater, string searchCriteria)
        {
            IList<IWebElement> lstTrElem = webActions.FindElement(tableLocater).FindElements(By.TagName("tr"));
            System.Threading.Thread.Sleep(3000);
            IWebElement row = lstTrElem.Where(item => item.Text.Contains(searchCriteria)).FirstOrDefault();
            System.Threading.Thread.Sleep(1000);
            IList<IWebElement> cells = row.FindElements(By.TagName("td"));
            IWebElement cell = cells.Where(item => item.Text.Contains(searchCriteria)).FirstOrDefault();
            cell.Click();
            System.Threading.Thread.Sleep(3000);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="webActions"></param>
        /// <param name="rowNumber"></param>
        public static string ClickTableAtRowAndCellNumber(this WebActions webActions, By tableLocater, int rowNumber, int cellNumber)
        {
            string InvestigationID = string.Empty;
            IList<IWebElement> lstTrElem = webActions.FindElement(tableLocater).FindElements(By.TagName("tr"));
            IWebElement row = lstTrElem[rowNumber];//for selecting first row
            IList<IWebElement> cells = row.FindElements(By.TagName("td"));
            IWebElement cell = cells[cellNumber];
            InvestigationID = cell.Text;
            cell.Click();
            System.Threading.Thread.Sleep(3000);

            return InvestigationID;

        }
       

        #endregion
    }
}
