using QCWService.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QCWService.Interface
{
    interface IMobileService
    {
        ReturnData DoService(ReceiveData receiveData);
    }
}
