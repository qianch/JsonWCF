using Autofac;
using Autofac.Core;
using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Web;
using SwaggerWcf.Attributes;
using System.Net;
using Autofac.Integration.Wcf;
using QCWService.Domain.Exceptions;
using QCWService.Infrastructure;
using QCWService.Domain.FrameUserAggregate;

namespace QCWService.Service
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    [FrameExceptionAttribute(typeof(FrameExceptionHandler))]
    [SwaggerWcf("/qcwservice/api")]
    public class JsonInfo : IJsonInfo
    {
        private readonly ILog logger = LogManager.GetLogger(typeof(JsonInfo));

        [SwaggerWcfTag("Api")]
        public string DoString(string receiveJson)
        {
            return new ReturnData().ToString();
        }

        [SwaggerWcfTag("Api")]
        public string DoWork()
        {
            return new ReturnData().ToString();
        }

        [SwaggerWcfTag("Api")]
        public Dictionary<string, object> DoDic(Dictionary<string, object> receiveJson)
        {
            return new Dictionary<string, object> { { "receiveJson", receiveJson } };
        }

        [SwaggerWcfTag("Api")]
        public string UserLogin(string receiveJson)
        {
            return new LoginService(new ReceiveData(receiveJson)).UserLogin().ToString();
        }

        [SwaggerWcfTag("Api")]
        public string AddUser(string receiveJson)
        {
            return new LoginService(new ReceiveData(receiveJson)).UserAdd().ToString();
        }

        [SwaggerWcfTag("Api")]
        public string GetDateTime()
        {
            return new ReturnData(new Dictionary<string, object>
            {
                { "DateTime", DateTime.Now }
            })
            .ToString();
        }
    }
}
