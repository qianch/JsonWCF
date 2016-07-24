using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace QCWTest
{
    [TestClass]
    public class TestLogin : Base
    {
        [TestMethod]
        public void UserLogin()
        {
            //准备数据
            var receive = new Dictionary<string, object>();
            receive.Add("ValidateData", ValidateData);

            var paras = new Dictionary<string, string>();
            paras.Add("LoginID", "QianChen");
            paras.Add("Password", "loveyou");
            receive.Add("paras", paras);

            //测试UserLogin
            WebClient client = new WebClient();
            client.Headers["Content-Type"] = "application/json";
            var receiveJson = JsonConvert.SerializeObject(receive);
            string request = client.UploadString(ServiceUrl + "/UserLogin", "POST", receiveJson);
            Console.Write(request);
        }
    }
}
