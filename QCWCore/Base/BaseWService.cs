using QCWCore.Entity;
using QCWCore.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QCWCore.Base
{
    public class BaseWService : IWService
    {
        public virtual ReturnData DoService(ReceiveData receiveData)
        {
            return new ReturnData();
        }
    }
}
