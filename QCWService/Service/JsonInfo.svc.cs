using log4net;
using QCWCore.Common;
using QCWCore.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Web;

namespace QCWService.Service
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class JsonInfo
    {
        private readonly ILog logger = LogManager.GetLogger(typeof(JsonInfo));
        private readonly Assembly ass = Assembly.LoadFrom(AppDomain.CurrentDomain.BaseDirectory + Path.Combine(new string[] { "bin", "QCWService.dll" }));

        [OperationContract]
        [WebInvoke(Method = "*", UriTemplate = "DoWork")]
        public string DoWork()
        {
            return new ReturnData().ToString();
        }

        [OperationContract]
        [WebInvoke(Method = "*")]
        public string DoString(string receiveJson)
        {
            ReturnData rtn = new ReturnData();
            rtn.AddUserData("receiveJson", receiveJson);
            return rtn.ToString();
        }

        [OperationContract]
        [WebInvoke(Method = "*")]
        public Dictionary<string, object> DoDic(Dictionary<string, object> receiveJson)
        {
            ReturnData rtn = new ReturnData();
            rtn.AddUserData("receiveJson", receiveJson);
            return new Dictionary<string, object> { { "receiveJson", receiveJson } };
        }

        [OperationContract]
        public string UserLogin(string receiveJson)
        {
            Type type = ass.GetType("QCWService.Service.LoginService");
            return ServiceUtil.DoService(receiveJson, type);
        }

        [OperationContract]
        [WebInvoke(Method = "*")]
        public string User_GetDateTime()
        {
            ReturnData ret = new ReturnData();
            ret.AddUserData("DateTime", DateTime.Now);
            return ret.ToString();
        }
    }
}
