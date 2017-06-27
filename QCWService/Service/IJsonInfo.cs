using SwaggerWcf.Attributes;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace QCWService.Service
{
    [ServiceContract(Namespace = "")]
    public interface IJsonInfo
    {
        [OperationContract]
        [WebInvoke(Method = "*")]
        [SwaggerWcfPath("Create DoString","Create a book on the Store")]
        string DoString(string receiveJson);

        [OperationContract]
        [WebInvoke(Method = "*", UriTemplate = "DoWork")]
        string DoWork();

        [OperationContract]
        [WebInvoke(Method = "*")]
        Dictionary<string, object> DoDic(Dictionary<string, object> receiveJson);

        [OperationContract]
        [WebInvoke(Method = "*")]
        string UserLogin(string receiveJson);

        [OperationContract]
        [WebInvoke(Method = "*")]
        string User_GetDateTime();
    }
}