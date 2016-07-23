using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;

namespace QCWTest
{
    [TestClass]
    public class TestDoWork : Base
    {
        [TestMethod]
        public void DoWork()
        {
            //准备数据
            var receive = new Dictionary<string, object>();
            receive.Add("ValidateData", ValidateData);
            receive.Add("paras", "paras");

            //测试dowork
            WebClient client = new WebClient();
            client.Headers["Content-Type"] = "application/json";
            var receiveJson = JsonConvert.SerializeObject(receive);
            string request = client.UploadString(ServiceUrl + "/DoWork", "POST", receiveJson);
            Console.Write(request);
        }
    }
}
