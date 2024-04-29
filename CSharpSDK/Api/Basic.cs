using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpSDK.Api
{
    public class Basic:RequestBase
    {
        public Config config;

        public Basic(Config config)
        {
            this.config = config;
        }
        /// <summary>
        /// 轨迹查询接口
        /// </summary>
        /// <returns></returns>
        public string ApiOrderRoute(string external=null,string express=null)
        {
            if (external == null && express == null)
            {
                throw new Exception("用户系统订单号与花务通订单号不能同时为空");
            }
            string action = "basic.query.orderroute";
            BasicData.OrderRouteRequest request = new BasicData.OrderRouteRequest(action,external, express);
            string response = this.request(action, request,this.config);
            return response;
        }
    }
}
