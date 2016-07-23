using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QCWCore.Entity
{
    public class ReceiveData
    {
        private string _validatedata;
        private string _paras;
        private Dictionary<string, object> _params;

        public ReceiveData()
        {
            _params = new Dictionary<string, object>();
        }

        public string ValidateData
        {
            set { _validatedata = value; }
            get { return _validatedata; }
        }
        public string Paras
        {
            set { _paras = value; }
            get { return _paras; }
        }

        public void SetParams(Dictionary<string, object> Params)
        {
            _params = Params;
        }

        public string GetParam(string paramName)
        {
            if (!_params.ContainsKey(paramName.Trim()))
            {
                throw new Exception(paramName + "参数不存在！");
            }
            return _params[paramName.Trim()].ToString();
        }

        public string GetParamNoException(String paramName)
        {
            if (!_params.ContainsKey(paramName.Trim()))
            {
                return "";
            }
            else
            {
                return _params[paramName.Trim()].ToString();
            }
        }
    }
}
