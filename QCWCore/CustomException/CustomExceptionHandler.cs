using log4net;
using QCWCore.Entity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Text;

namespace QCWCore.CustomException
{
    public class CustomExceptionHandler : IErrorHandler
    {
        private readonly ILog logger = LogManager.GetLogger(typeof(CustomExceptionHandler));
        public bool HandleError(System.Exception error)
        {
            logger.Error(error.ToString());
            return false;
        }

        public void ProvideFault(System.Exception error, MessageVersion version, ref Message fault)
        {
            //The fault to be returned  
            fault = Message.CreateMessage(version, "", new ReturnData(ReturnStatus.Error, error.ToString()).ToString(), new DataContractJsonSerializer(typeof(string)));

            // tell WCF to use JSON encoding rather than default XML  
            WebBodyFormatMessageProperty wbf = new WebBodyFormatMessageProperty(WebContentFormat.Json);

            // Add the formatter to the fault  
            fault.Properties.Add(WebBodyFormatMessageProperty.Name, wbf);

            //Modify response  
            HttpResponseMessageProperty rmp = new HttpResponseMessageProperty();

            // return custom error code, 500.  
            rmp.StatusCode = System.Net.HttpStatusCode.InternalServerError;
            rmp.StatusDescription = "InternalServerError";

            //Mark the jsonerror and json content  
            rmp.Headers[HttpResponseHeader.ContentType] = "application/json";
            rmp.Headers[HttpResponseHeader.ContentEncoding] = "utf-8";

            //Add to msg  
            fault.Properties.Add(HttpResponseMessageProperty.Name, rmp);

        }
    }
}
