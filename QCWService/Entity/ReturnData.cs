using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QCWService.Entity
{
    public class ReturnData
    {
        private ReturnStatus _returnstatus;
        private string _description;
        private Dictionary<string, object> _userdata;
        private string _data;

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
        }

        public void AddUserData(string key, object value)
        {
            _userdata.Add(key, value);
        }

        public void AddUserData(string key, string value)
        {
            _userdata.Add(key, value);
        }

        public void AddUserData(string key, int value)
        {
            _userdata.Add(key, Convert.ToString(value));
        }

        public string Data
        {
            set { _data = value; }
            get { return _data; }
        }
    }
}