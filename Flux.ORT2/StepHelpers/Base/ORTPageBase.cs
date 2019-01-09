//using Flux.ORT.Common;
using Flux.ORT2.CommonUtils;
//using Flux.APS.StepHelpers.APSCommonPageFunctions;
using Flux.ORT2.StepHelpers.CommonPageFunctions;
using Flux.Core;
using Flux.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flux.ORT2.Base
{

    public abstract class ORTPageBase : WebPageBase
    {
        //public override string URL => Url;

        //public abstract string Url { get; }
        //public CalenderMethdos Calender { get => new CalenderMethdos(Singleton.GetService<WebEnvironment>()); }

        //public CommonBusinessComponents CommonBusiness { get => new CommonBusinessComponents(Singleton.GetService<WebEnvironment>()); }

        //public MenuActions Menu { get => new MenuActions(Singleton.GetService<WebEnvironment>()); }

        //public CommonFunctions CommonFunc { get => new CommonFunctions(Singleton.GetService<WebEnvironment>()); }

        // public ORTCommonFunctionsForAnalysis TableAReports { get => new ORTCommonFunctionsForAnalysis(Singleton.GetService<WebEnvironment>()); }

        public static void StaticSleep(int SleepTime)
        {
            System.Threading.Thread.Sleep(SleepTime);
        }
    }
}
