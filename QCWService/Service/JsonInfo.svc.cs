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

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace QCWService.Service
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class JsonInfo
    {
        private readonly ILog logger = LogManager.GetLogger(typeof(JsonInfo));
        private readonly Assembly ass = Assembly.LoadFrom(HttpContext.Current.Server.MapPath("~/bin/QCWService.dll"));
        // 要使用 HTTP GET，请添加 [WebGet] 特性。(默认 ResponseFormat 为 WebMessageFormat.Json)
        // 要创建返回 XML 的操作，
        // 请添加 [WebGet(ResponseFormat=WebMessageFormat.Xml)]，
        // 并在操作正文中包括以下行:
        // WebOperationContext.Current.OutgoingResponse.ContentType = "text/xml";
        [OperationContract]
        public Dictionary<string, object> DoWork()
        {
            return ServiceUtil.ToReturnData(new ReturnData());
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
