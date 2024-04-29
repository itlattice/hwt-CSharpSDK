using CSharpSDK.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSDK.Api.BasicData
{
    class OrderRouteRequest
    {
        public string external = null;
        public string express = null;
        public string request_id;
        public string action;

        public OrderRouteRequest(string action,string external = null, string express = null)
        {
            this.express = express;
            this.external = external;
            this.action = action;
            this.request_id = Common.getUUID();
        }
    }
}
