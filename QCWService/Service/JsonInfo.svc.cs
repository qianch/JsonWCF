using Autofac;
using Autofac.Core;
using log4net;
using QCWCore.CustomException;
using QCWCore.Entity;
using QCWCore.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Web;
using SwaggerWcf.Attributes;

namespace QCWService.Service
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [CustomExceptionAttribute(typeof(CustomExceptionHandler))]
    public class JsonInfo
    {
        private readonly ILog logger = LogManager.GetLogger(typeof(JsonInfo));

        [SwaggerWcfTag("DoWork")]
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
            return new ReturnData().ToString();
        }

        [OperationContract]
        [WebInvoke(Method = "*")]
        public Dictionary<string, object> DoDic(Dictionary<string, object> receiveJson)
        {
            return new Dictionary<string, object> { { "receiveJson", receiveJson } };
        }

        [OperationContract]
        [WebInvoke(Method = "*")]
        public string UserLogin(string receiveJson)
        {
            //return new LoginService(new ReceiveData(receiveJson)).UserLogin().ToString();
            var builder = new ContainerBuilder();
            builder.RegisterType<ReceiveData>()
                   .WithParameter(new NamedParameter("receiveJson", receiveJson))
                   .As<IReceiveData>();
            builder.RegisterType<LoginService>();

            using (var container = builder.Build())
            {
                var manager = container.Resolve<LoginService>();
                return manager.UserLogin().ToString();
            }
        }

        [OperationContract]
        [WebInvoke(Method = "*")]
        public string User_GetDateTime()
        {
            return new ReturnData(new Dictionary<string, object>
            {
                { "DateTime", DateTime.Now }
            })
            .ToString();
        }
    }
}
