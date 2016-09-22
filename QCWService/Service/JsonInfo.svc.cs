using log4net;
using QCWCore.Common;
using QCWCore.Entity;
using System;
using System.Collections.Generic;
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
        private readonly Assembly ass = Assembly.LoadFrom(HttpContext.Current.Server.MapPath("~/bin/QCWService.dll"));

        [OperationContract]
        [WebInvoke(Method = "*")]
        public Dictionary<string, object> DoWork()
        {
            return ServiceUtil.ToReturnData(new ReturnData());
        }

        [OperationContract]
        [WebInvoke(Method = "*")]
        public Dictionary<string, object> Do(Dictionary<string, object> receiveJson)
        {
            ReturnData rtn = new ReturnData();
            rtn.AddUserData("receiveJson", receiveJson);
            return ServiceUtil.ToReturnData(rtn);
        }

        [OperationContract]
        public Dictionary<string, object> UserLogin(Dictionary<string, object> receiveJson)
        {
            Type type = ass.GetType("QCWService.Service.LoginService");
            return ServiceUtil.DoService(receiveJson, type);
        }

        [OperationContract]
        public Dictionary<string, object> User_GetDateTime()
        {
            ReturnData ret = new ReturnData();
            ret.AddUserData("DateTime", string.Format("{0:yyyy-MM-dd HH:mm:ss}", DateTime.Now));
            return ServiceUtil.ToReturnData(ret);
        }
    }
}
