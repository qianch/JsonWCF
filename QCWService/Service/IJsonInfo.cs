using SwaggerWcf.Attributes;
using System.Collections.Generic;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace QCWService.Service
{
    [ServiceContract(Namespace = "")]
    public interface IJsonInfo
    {
        [WebInvoke(UriTemplate = "DoString")]
        [OperationContract]
        string DoString(string receiveJson);

        [OperationContract]
        [WebInvoke(UriTemplate = "DoWork")]
        string DoWork();

        [OperationContract]
        [WebInvoke(UriTemplate = "DoDic")]
        Dictionary<string, object> DoDic(Dictionary<string, object> receiveJson);

        [OperationContract]
        [WebInvoke(UriTemplate = "UserLogin")]
        string UserLogin(string receiveJson);

        [OperationContract]
        [WebInvoke(UriTemplate = "GetDateTime")]
        string GetDateTime();
    }
}