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
    public class TestDo : Base
    {
        [TestMethod]
        public void Do()
        {
            //准备数据
            var receive = new Dictionary<string, object>();
            receive.Add("ValidateData", ValidateData);
            receive.Add("paras", "paras");

            //测试do
            WebClient client = new WebClient();
            client.Headers["Content-Type"] = "application/json";
            var receiveJson = JsonConvert.SerializeObject(receive);
            string requestPOST = client.UploadString(ServiceUrl + "/Do", "POST", receiveJson);
            Console.Write(requestPOST);

            string requestGET = Get(ServiceUrl + "/Do?" + receiveJson);
            Console.Write(requestGET);
        }
    }
}
