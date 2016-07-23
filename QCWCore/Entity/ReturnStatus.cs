using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QCWCore.Entity
{
    public enum ReturnStatus
    {
        True = 1,  // 程序与业务都没有报错
        False = 2, // 程序报错
        Error = 3  //  业务报错
    };
}
