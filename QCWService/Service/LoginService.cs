using log4net;
using QCWCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QCWService.Service
{
    public class LoginService : BaseService
    {
        private readonly ILog logger = LogManager.GetLogger(typeof(LoginService));

        public LoginService(ReceiveData receiveData) : base(receiveData)
        {

        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        public ReturnData UserLogin()
        {

            string loginID = receiveData.GetStringMust("LoginID");
            string passWord = receiveData.GetStringMust("Password");

            //TODO

            return new ReturnData(new Dictionary<string, object>
            {
                {"Description","登录成功" },
                {"UserGuid","UserGuid" },
                {"DanWeiGuid","DanWeiGuid" },
                {"DanWeiName","DanWeiName" }
            });
        }

        public ReturnData User_Add(ReceiveData receiveData)
        {
            //TODO
            return new ReturnData();
        }
    }
}