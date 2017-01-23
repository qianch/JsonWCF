using log4net;
using QCWCore.Common;
using QCWCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QCWService.Service
{
    public class LoginService : MobileService
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
            if (returnData.Status == ReturnStatus.True)
            {
                string loginID = "";
                string passWord = "";
                try
                {
                    validateData = receiveData.ValidateData;
                    loginID = receiveData.GetParam("LoginID");
                    passWord = receiveData.GetParam("Password");
                }
                catch (Exception ex)
                {
                    logger.Error("输入参数不合法", ex);
                    return new ReturnData(ReturnStatus.Error, "输入参数不合法" + ex.ToString());
                }
                var dicParam = new Dictionary<string, string>();
                dicParam.Add("LoginID", loginID);
                dicParam.Add("PassWord", passWord);
                string msg = Function.CheckParam(dicParam, validateData);
                if (msg != "")
                {
                    return new ReturnData(ReturnStatus.False, msg);
                }

                returnData.Description = "登录成功";
                returnData.AddUserData("UserGuid", dearJsonValue("userguid"));
                returnData.AddUserData("UserName", dearJsonValue("username"));
                returnData.AddUserData("DanWeiGuid", dearJsonValue("danweiguid"));
                returnData.AddUserData("DanWeiName", dearJsonValue("danweiname"));
            }
            return returnData;
        }

        public ReturnData User_Add(ReceiveData receiveData)
        {
            //todo
            return new ReturnData();
        }
    }
}