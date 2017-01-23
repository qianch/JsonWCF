using QCWCore.Base;
using QCWCore.Entity;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace QCWService.Service
{
    public class MobileService : BaseWService
    {
        protected ReceiveData receiveData;
        protected ReturnData returnData;
        protected string validateData = "";
        protected string currentPageIndex = "";
        protected string pageSize = "20";
        protected string userGuid = "";
        protected string keyWord = "";
        protected string startDate = "";
        protected string endDate = "";
        protected string areaCode = "";

        public MobileService(ReceiveData receiveData)
        {
            this.receiveData = receiveData;
            returnData = new ReturnData();
            if (receiveData.IsStandard == false)
            {
                returnData.Status = ReturnStatus.Error;
                Dictionary<string, object> ret = new Dictionary<string, object>
                {
                    {"ValidateData","Data" },
                    {"paras",new Dictionary<string,string> { {"A","aa" }, { "B","bb"} } }
                };
                returnData.Description = "传入的json不合法,参考格式：" + Newtonsoft.Json.JsonConvert.SerializeObject(ret);
            }
            else
            {
                returnData.Status = ReturnStatus.True;
            }
        }

        public override ReturnData DoService(ReceiveData receiveData)
        {
            return new ReturnData();
        }

        protected string dearStartDate()
        {
            if (string.IsNullOrEmpty(startDate))
            {
                return startDate = DateTime.Now.AddMonths(-1).ToString("yyyy-MM-HH");
            }
            return startDate;
        }

        protected string dearEndDate()
        {
            if (string.IsNullOrEmpty(endDate))
            {
                return endDate = DateTime.Now.ToString("yyyy-MM-HH");
            }
            return endDate;
        }


        protected int dearFirstIndex()
        {
            if (string.IsNullOrEmpty(currentPageIndex))
            {
                currentPageIndex = "1";
            }
            return (int.Parse(currentPageIndex) - 1) * dearPageSize();
        }

        protected int dearEndIndex()
        {
            if (string.IsNullOrEmpty(currentPageIndex))
            {
                currentPageIndex = "1";
            }
            return int.Parse(currentPageIndex) * dearPageSize() - 1;
        }

        protected int dearPageSize()
        {
            if (string.IsNullOrEmpty(pageSize))
            {
                pageSize = "20";
            }
            return int.Parse(pageSize);
        }

        protected string dearJsonValue(object value)
        {
            string v = Convert.ToString(value);
            if (string.IsNullOrEmpty(v) || v == "null")
            {
                return "";
            }
            else
            {
                return v;
            }
        }
    }
}