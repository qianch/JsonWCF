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

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="receiveData"></param>
        /// <returns></returns>
        public ReturnData UserLogin(ReceiveData receiveData)
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
            string msg = Common.CheckParam(dicParam, validateData);
            if (msg != "")
            {
                return new ReturnData(ReturnStatus.False, msg);
            }

            ReturnData ret = new ReturnData();
            ret.Description = "登录成功";
            ret.AddUserData("UserGuid", dearJsonValue("userguid"));
            ret.AddUserData("UserName", dearJsonValue("username"));
            ret.AddUserData("DanWeiGuid", dearJsonValue("danweiguid"));
            ret.AddUserData("DanWeiName", dearJsonValue("danweiname"));
            return ret;
        }

        public ReturnData User_Add(ReceiveData receiveData)
        {
            //todo
            return new ReturnData();
        }
    }
}