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

        public static String Get(string url)
        {
            System.Net.HttpWebRequest request = System.Net.WebRequest.Create(url) as System.Net.HttpWebRequest;
            request.Method = "GET";
            System.Net.HttpWebResponse result = request.GetResponse() as System.Net.HttpWebResponse;
            System.IO.StreamReader sr = new System.IO.StreamReader(result.GetResponseStream(), Encoding.UTF8);
            string strResult = sr.ReadToEnd();
            sr.Close();
            return strResult;
        }
    }
}
