using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QCWCore.Entity
{
    public class ReceiveData
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(ReceiveData));
        private string _validatedata;
        private string _paras;
        private bool _isStandard;
        private Dictionary<string, object> _params;

        public ReceiveData()
        {
            _params = new Dictionary<string, object>();
        }

        public ReceiveData(string receiveJson)
        {
            try
            {
                Dictionary<string, object> receiveDic = JsonConvert.DeserializeObject<Dictionary<string, object>>(receiveJson);
                Dictionary<string, object> p = JsonConvert.DeserializeObject<Dictionary<string, object>>(receiveDic["paras"].ToString());
                SetParams(p);
                _validatedata = receiveDic["ValidateData"].ToString();
                _isStandard = true;
            }
            catch (Exception e)
            {
                _logger.Error(e.ToString());
                _isStandard = false;
            }
        }

        public bool IsStandard { get { return _isStandard; } }

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
