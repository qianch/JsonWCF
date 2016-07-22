using QCWService.DB;
using QCWService.Entity;
using QCWService.Interface;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace QCWService.Service
{
    public class MobileService : IMobileService
    {
        public static string detailUrl = System.Configuration.ConfigurationManager.AppSettings["Detail_url"];
        protected string validateData = "";
        protected string currentPageIndex = "";
        protected string pageSize = "20";
        protected string userGuid = "";
        protected string keyWord = "";
        protected string startDate = "";
        protected string endDate = "";
        protected string areaCode = "";

        public ReturnData DoService(ReceiveData receiveData)
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