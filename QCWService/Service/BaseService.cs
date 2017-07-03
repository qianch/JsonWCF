using QCWService.Infrastructure;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace QCWService.Service
{
    public class BaseService
    {
        protected ReceiveData ReceiveData;
        protected string validateData = "";
        protected string currentPageIndex = "";
        protected string pageSize = "20";
        protected string userGuid = "";
        protected string keyWord = "";
        protected string startDate = "";
        protected string endDate = "";
        protected string areaCode = "";

        public BaseService(ReceiveData ReceiveData)
        {
            this.ReceiveData = ReceiveData;
        }
    }
}