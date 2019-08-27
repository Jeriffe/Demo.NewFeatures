
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Demo.BasicFeatures
{
    public class _CommonHelper
    {

        public int Image_DefaultSize = 0;
        public string Image_DrugImageUrl = "";
        public SysConfigParamBLC blcSysConfig = new SysConfigParamBLC();

        private Regex drugUrlRegex = new Regex(@"(https?|ftp|file)://[-A-Za-z0-9+&@#/%?=~_|!:,.;]+[-A-Za-z0-9+&@#/%=~_|]");

        public string Image_ExtensionName { get; private set; }
        public string DrugImageUrl { get { return blcSysConfig.DrugImageUrl; } }

        public _CommonHelper()
        {
            Image_ExtensionName = "jpg";

            if (null != ConfigurationManager.AppSettings["DrugImageType"])
            {
                Image_ExtensionName = ConfigurationManager.AppSettings["DrugImageType"];
            }

            if (null != ConfigurationManager.AppSettings["DrugImageDefaultSize"])
            {
                int size = 0;
                if (int.TryParse(ConfigurationManager.AppSettings["DrugImageDefaultSize"], out size))
                {
                    Image_DefaultSize = size;
                }
            }
        }

        /// <summary>
        /// return boolean of is DrugImage allowed shown.
        /// </summary>
        /// <returns></returns>
        public bool IsDrugImageShowOpened()
        {
            return drugUrlRegex.IsMatch(blcSysConfig.DrugImageUrl) && blcSysConfig.AllowOnlineDrugInfoLookup;
        }
    }
}
