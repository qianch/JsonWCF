using Autofac;
using Autofac.Integration.Wcf;
using log4net;
using QCWService.Domain.FrameUserAggregate;
using QCWService.Infrastructure;
using QCWService.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QCWService.Service
{
    public class LoginService : BaseService
    {
        private readonly ILog logger = LogManager.GetLogger(typeof(LoginService));

        public LoginService(ReceiveData ReceiveData) : base(ReceiveData)
        {

        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        public ReturnData UserLogin()
        {

            string loginID = ReceiveData.GetStringMust("LoginID");
            string password = ReceiveData.GetStringMust("Password");
            FrameContext context = AutofacHostFactory.Container
               .Resolve<FrameContext>().Init();

            return new ReturnData(new Dictionary<string, object>
                {
                    {"Description","登录成功" },
                    {"UserGuid","UserGuid" },
                    {"DanWeiGuid","DanWeiGuid" },
                    {"DanWeiName","DanWeiName" }
                });
        }

        public ReturnData UserAdd()
        {
            string loginID = ReceiveData.GetStringMust("LoginID");
            string password = ReceiveData.GetStringMust("Password");
            string displayName = ReceiveData.GetStringNoException("DisplayName");
            var userRepository = AutofacHostFactory.Container
                .Resolve<IFrameUserRepository>();
            userRepository.Add(new FrameUser { LoginID = loginID, UserGuid = Guid.NewGuid(), DisplayName = displayName, Password = password });
            return new ReturnData();
        }
    }
}