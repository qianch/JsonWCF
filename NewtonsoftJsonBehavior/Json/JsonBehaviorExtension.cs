using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Configuration;
using System.Web;

namespace JsonBehavior.Json
{
    public class JsonBehaviorExtension : BehaviorExtensionElement
    {
        public override Type BehaviorType
        {
            get { return typeof(JsonBehavior); }
        }

        protected override object CreateBehavior()
        {
            return new JsonBehavior();
        }

    }
}
