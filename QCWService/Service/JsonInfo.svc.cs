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
        [SwaggerWcfHeader("clientId", false, "Client ID", "000")]
        [SwaggerWcfResponse(HttpStatusCode.NotFound, "address is error", true)]
        [SwaggerWcfResponse(HttpStatusCode.BadRequest, "Bad request", true)]
        [SwaggerWcfResponse(HttpStatusCode.InternalServerError, "Internal error (Do Fail)", true)]
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
            return AutofacHostFactory
                .Container
                .Resolve<LoginService>(new NamedParameter("ReceiveData", new ReceiveData(receiveJson)))
                .UserLogin()
                .ToString();
        }

        [SwaggerWcfTag("Api")]
        public string GetDateTime()
        {
            return new ReturnData(new Dictionary<string, object>
            {
                { "DateTime", DateTime.Now }
            }).ToString();
        }
    }
}
