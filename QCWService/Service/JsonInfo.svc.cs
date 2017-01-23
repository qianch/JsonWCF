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
            return new LoginService(new ReceiveData(receiveJson)).UserLogin().ToString();
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
