using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Reflection;
using System.Diagnostics;
using QCWCore.Entity;
using Newtonsoft.Json.Converters;

namespace QCWCore.Common
{
    public class ServiceUtil
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(ServiceUtil));

        public static string DoService(string receiveJson, Type type)
        {
            StackTrace st = new StackTrace(true);
            return DoService(receiveJson, type, st.GetFrame(1).GetMethod().Name);
        }

        public static string DoService(string receiveJson, Type type, string methodName)
        {
            try
            {
                logger.Debug(methodName + "收到参数" + JsonConvert.SerializeObject(receiveJson));
                ReceiveData receiveData = new ReceiveData(receiveJson);
                MethodInfo method = type.GetMethod(methodName);
                if (method == null)
                {
                    string msg = "根据方法名：" + methodName + "没能反射获取到正确的方法，请检查服务类：" + type.Name + "中是否有此方法，或者有以此开头的方法";
                }
                object obj = Activator.CreateInstance(type);
                ReturnData retrunData = (ReturnData)method.Invoke(obj, new object[] { receiveData });
                return retrunData.ToString();
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return new ReturnData(ReturnStatus.Error, "服务出错!" + ex.ToString()).ToString();
            }
        }
    }
}
