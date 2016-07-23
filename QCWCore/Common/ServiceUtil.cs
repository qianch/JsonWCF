using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Reflection;
using System.Diagnostics;
using QCWCore.Entity;

namespace QCWCore.Common
{
    public class ServiceUtil
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(ServiceUtil));

        public static ReceiveData FormReceiveData(Dictionary<string, object> receiveJson)
        {
            ReceiveData ret = new ReceiveData();
            Dictionary<string, object> p = JsonConvert.DeserializeObject<Dictionary<string, object>>(receiveJson["paras"].ToString());
            ret.SetParams(p);
            ret.ValidateData = receiveJson["ValidateData"].ToString();
            return ret;
        }

        public static Dictionary<string, object> ToReturnData(ReturnData returnData)
        {
            var retDic = new Dictionary<string, object>();
            // 程序是否出错信息
            var dic1 = new Dictionary<string, string>();
            if (returnData.Status == ReturnStatus.Error)
            {
                dic1.Add("Code", "0");
                dic1.Add("Description", returnData.Description);
            }
            else
            {
                dic1.Add("Code", "1");
                dic1.Add("Description", "");
            }
            retDic.Add("ReturnInfo", dic1);//加入第一串ReturnInfo

            // 业务是否出错信息
            var dic2 = new Dictionary<string, string>();
            if (returnData.Status == ReturnStatus.False)
            {
                dic2.Add("Code", "0");
                dic2.Add("Description", returnData.Description);
            }
            else
            {
                dic2.Add("Code", "1");
                dic2.Add("Description", "");
            }
            retDic.Add("BusinessInfo", dic2);//加入第二串BusinessInfo

            // 用户数据
            var dic3 = new Dictionary<string, object>();
            foreach (string key in returnData.UserData.Keys)
            {
                dic3.Add(key, returnData.UserData[key]);
            }
            retDic.Add("UserArea", dic3);//加入第三串UserArea
            return retDic;
        }

        public static Dictionary<string, object> DoService(Dictionary<string, object> receiveJson, Type type)
        {
            StackTrace st = new StackTrace(true);
            return DoService(receiveJson, type, st.GetFrame(1).GetMethod().Name);
        }

        public static Dictionary<string, object> DoService(Dictionary<string, object> receiveJson, Type type, string methodName)
        {
            try
            {
                logger.Debug(methodName + "收到参数" + JsonConvert.SerializeObject(receiveJson));
                ReceiveData receiveData = FormReceiveData(receiveJson);
                MethodInfo method = type.GetMethod(methodName);
                if (method == null)
                {
                    string msg = "根据方法名：" + methodName + "没能反射获取到正确的方法，请检查服务类：" + type.Name + "中是否有此方法，或者有以此开头的方法";
                }
                object obj = Activator.CreateInstance(type);
                ReturnData retrunData = (ReturnData)method.Invoke(obj, new object[] { receiveData });
                return ToReturnData(retrunData);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return ToReturnData(new ReturnData(ReturnStatus.Error, "服务出错!" + ex.Message));
            }
        }
    }
}
