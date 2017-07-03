using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCWService.Infrastructure
{
    public enum ReturnStatus
    {
        True = 1,  // 程序与业务都没有报错
        False = 2, // 程序报错
        Error = 3  //  业务报错
    };
}
