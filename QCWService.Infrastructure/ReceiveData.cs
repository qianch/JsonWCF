using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCWService.Infrastructure
{
    public class ReceiveData
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(ReceiveData));
        private string _validateData = System.Configuration.ConfigurationManager.AppSettings["ValidateData"];
        private Dictionary<string, object> _params;

        public ReceiveData()
        {
            _params = new Dictionary<string, object>();
        }

        public ReceiveData(string receiveJson)
        {
            string validateData = "";
            try
            {
                Dictionary<string, object> receiveDic = JsonConvert.DeserializeObject<Dictionary<string, object>>(receiveJson);
                _params = JsonConvert.DeserializeObject<Dictionary<string, object>>(receiveDic["paras"].ToString());
                validateData = receiveDic["ValidateData"].ToString();
            }
            catch (Exception e)
            {
                _logger.Error(e.ToString());
                throw new Exception("参数不是标准格式" + e.ToString());
            }

            if (validateData != _validateData)
            {
                _logger.Error("非法调用");
                throw new Exception("非法调用");
            }
        }

        public string GetStringMust(string name)
        {
            if (_params.ContainsKey(name.Trim()))
            {
                return _params[name.Trim()].ToString();
            }
            else
            {
                throw new Exception(name + "必填项");
            }
        }

        public string GetString(string name)
        {
            if (!_params.ContainsKey(name.Trim()))
            {
                throw new Exception(name + "参数不存在！");
            }
            return _params[name.Trim()].ToString();
        }

        public string GetStringNoException(String name)
        {
            if (!_params.ContainsKey(name.Trim()))
            {
                return "";
            }
            else
            {
                return _params[name.Trim()].ToString();
            }
        }
    }
}
