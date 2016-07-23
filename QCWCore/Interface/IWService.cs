using QCWCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QCWCore.Interface
{
    interface IWService
    {
        ReturnData DoService(ReceiveData receiveData);
    }
}
