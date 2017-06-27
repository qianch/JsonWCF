using log4net;
using QCWCore.DB;
using QCWCore.Entity;
using QCWCore.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QCWService.Service
{
    public class LoginService : BaseService
    {
        private readonly ILog logger = LogManager.GetLogger(typeof(LoginService));

        public LoginService(IReceiveData ReceiveData) : base(ReceiveData)
        {

        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        public ReturnData UserLogin()
        {

            string loginID = ReceiveData.GetStringMust("LoginID");
            string passWord = ReceiveData.GetStringMust("Password");

            //TODO
            var users = new DBBase().DBContext.Frame_User.All();
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