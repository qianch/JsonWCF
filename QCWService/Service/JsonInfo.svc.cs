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
using System.Net;

namespace QCWService.Service
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    [CustomExceptionAttribute(typeof(CustomExceptionHandler))]
    [SwaggerWcf("/qcwservice/api")]
    public class JsonInfo : IJsonInfo
    {
        private readonly ILog logger = LogManager.GetLogger(typeof(JsonInfo));

        [SwaggerWcfTag("Strings")]
        [SwaggerWcfHeader("clientId", false, "Client ID", "000")]
        [SwaggerWcfResponse(HttpStatusCode.Created, "Book created, value in the response body with id updated")]
        [SwaggerWcfResponse(HttpStatusCode.BadRequest, "Bad request", true)]
        [SwaggerWcfResponse(HttpStatusCode.InternalServerError,
            "Internal error (can be forced using ERROR_500 as book title)", true)]
        public string DoString(string receiveJson)
        {
            return new ReturnData().ToString();
        }

        [SwaggerWcfTag("Strings")]
        public string DoWork()
        {
            return new ReturnData().ToString();
        }

        [SwaggerWcfTag("Strings")]
        public Dictionary<string, object> DoDic(Dictionary<string, object> receiveJson)
        {
            return new Dictionary<string, object> { { "receiveJson", receiveJson } };
        }

        [SwaggerWcfTag("Strings")]
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

        [SwaggerWcfTag("Strings")]
        public string GetDateTime()
        {
            return new ReturnData(new Dictionary<string, object>
            {
                { "DateTime", DateTime.Now }
            }).ToString();
        }
    }
}
