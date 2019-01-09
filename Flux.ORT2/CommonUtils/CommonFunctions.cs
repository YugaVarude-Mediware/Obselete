using Flux.ORT2.Enums;
//using Flux.APS.StepHelpers;
using Flux.Web;
using OpenQA.Selenium;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flux.ORT2.CommonUtils
{
    public class CommonFunctions
    {

        public CommonFunctions(WebEnvironment testEnvironment)
        {
            TestEnvironment = testEnvironment;
            Waits = new WebWaits(testEnvironment);
            Actions = new WebActions(testEnvironment);
        }

        private WebWaits Waits { get; set; }

        private WebActions Actions { get; set; }

        private WebEnvironment TestEnvironment { get; set; }

        /// <summary>
        /// This function takes String value and returns Enum value
        /// </summary>
        /// <param name="colour"></param>
        /// <returns></returns>
        public static T GetEnumNameFromString<T>(string Value)
        {
            foreach (T mc in Enum.GetValues(typeof(T)))
            {
                if (mc.ToString() == Value)
                    return mc;
            }
            return default(T);
        }


        /// <summary>
        /// This method will return all the locaters from the resource files
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="res"></param>
        /// <returns></returns>
        public IList<By> getlocatersFromResource<T>() where T : class
        {

            IList<By> allLocaters = new List<By>();

            Type type = typeof(T); // MyClass is static class with static properties

            foreach (var p in type.GetMethods(System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic))
            {
                var key = p.Name; // static classes cannot be instanced, so use null...
                                  //do something with v                
                if (key != null
                    && key != "get_ResourceManager"
                    && key != "get_Culture"
                    && key != "set_Culture")
                {
                    string value = p.Invoke(null, null).ToString();
                    if (key.ToLower().EndsWith("_id"))
                    {
                        allLocaters.Add(By.Id(value));
                    }
                    else if (key.ToLower().EndsWith("_xp") || key.ToLower().EndsWith("_xpath"))
                    {
                        allLocaters.Add(By.XPath(value));
                    }
                    else if (key.ToLower().EndsWith("_cls"))
                    {
                        allLocaters.Add(By.ClassName(value));
                    }

                }
            }



            return allLocaters;

        }


    }


}
