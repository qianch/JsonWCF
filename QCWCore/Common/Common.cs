using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QCWCore.Common
{
    public class Common
    {
        public static string ValidateData = System.Configuration.ConfigurationManager.AppSettings["ValidateData"];
        public static string CheckParam(Dictionary<string, string> dicParam, string validateData)
        {

            //复杂验证
            //if (TokenAuth.Check(validateData) == false)
            //{
            //    return "非法调用";
            //}

            //简单验证 约定一个validateData
            if (validateData != ValidateData)
            {
                return "非法调用";
            }

            foreach (KeyValuePair<string, string> kv in dicParam)
            {
                string key = kv.Key;
                string value = kv.Value;
                if (string.IsNullOrEmpty(value))
                {
                    return key + "参数为空！";
                }
            }
            return "";
        }
    }
}
