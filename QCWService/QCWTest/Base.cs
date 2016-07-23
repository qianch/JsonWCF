using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QCWTest
{
    public class Base
    {
        public static string ServiceUrl = System.Configuration.ConfigurationManager.AppSettings["ServiceUrl"];
        public static string ValidateData = System.Configuration.ConfigurationManager.AppSettings["ValidateData"];
    }
}
