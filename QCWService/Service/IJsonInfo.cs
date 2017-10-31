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
        [OperationContract]
        [WebInvoke(UriTemplate = "DoString")]
        [SwaggerWcfPath("参数为JSON字符串测试")]
        string DoString(string receiveJson);

        [OperationContract]
        [WebInvoke(UriTemplate = "DoWork")]
        [SwaggerWcfPath("无参数测试")]
        string DoWork();

        [OperationContract]
        [WebInvoke(UriTemplate = "DoDic")]
        [SwaggerWcfPath("参数为字典测试")]
        Dictionary<string, object> DoDic(Dictionary<string, object> receiveJson);

        [OperationContract]
        [SwaggerWcfPath("用户登录")]
        [WebInvoke(UriTemplate = "UserLogin")]
        string UserLogin(string receiveJson);

        [OperationContract]
        [SwaggerWcfPath("新增用户")]
        [WebInvoke(UriTemplate = "AddUser")]
        string AddUser(string receiveJson);

        [OperationContract]
        [SwaggerWcfPath("服务器时间")]
        [WebInvoke(UriTemplate = "GetDateTime")]
        string GetDateTime();
    }
}