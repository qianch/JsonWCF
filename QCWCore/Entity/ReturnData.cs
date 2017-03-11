using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QCWCore.Entity
{
    public class ReturnData
    {
        private ReturnStatus _returnstatus;
        private string _description;
        private Dictionary<string, object> _userdata;

        public ReturnData()
        {
            _userdata = new Dictionary<string, object>();
            _returnstatus = ReturnStatus.True;
        }

        public ReturnData(Dictionary<string, object> userData)
        {
            _userdata = userData;
            _returnstatus = ReturnStatus.True;
        }

        public ReturnData(ReturnStatus status, string msg)
        {
            _userdata = new Dictionary<string, object>();
            _returnstatus = status;
            _description = msg;
        }


        public ReturnStatus Status
        {
            set { _returnstatus = value; }
            get { return _returnstatus; }
        }

        public string Description
        {
            set { _description = value; }
            get { return _description; }
        }

        public Dictionary<string, object> UserData
        {
            get { return _userdata; }
            set { _userdata = value; }
        }

        public override string ToString()
        {
            var retDic = new Dictionary<string, object>();
            // 程序是否出错信息
            var dic1 = new Dictionary<string, string>();
            if (_returnstatus == ReturnStatus.Error)
            {
                dic1.Add("Code", "0");
                dic1.Add("Description", _description);
            }
            else
            {
                dic1.Add("Code", "1");
                dic1.Add("Description", "");
            }
            retDic.Add("ReturnInfo", dic1);//加入第一串ReturnInfo

            // 业务是否出错信息
            var dic2 = new Dictionary<string, string>();
            if (_returnstatus == ReturnStatus.False)
            {
                dic2.Add("Code", "0");
                dic2.Add("Description", _description);
            }
            else
            {
                dic2.Add("Code", "1");
                dic2.Add("Description", "");
            }
            retDic.Add("BusinessInfo", dic2);//加入第二串BusinessInfo

            // 用户数据
            retDic.Add("UserArea", _userdata);//加入第三串UserArea
            IsoDateTimeConverter timeConverter = new IsoDateTimeConverter() { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" };
            return JsonConvert.SerializeObject(retDic, timeConverter);
        }
    }
}
