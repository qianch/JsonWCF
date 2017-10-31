using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.DynamicProxy;
using log4net;

namespace QCService.Interceptor
{
    public class AuthorizeInterceptor : IInterceptor
    {
        private ILog _logger = log4net.LogManager.GetLogger(typeof(AuthorizeInterceptor));
        public void Intercept(IInvocation invocation)
        {
            var args = invocation.Arguments;
            _logger.Info(invocation.Method.Name);
            invocation.Proceed();
        }
    }
}
