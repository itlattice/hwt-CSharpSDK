using CSharpSDK.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSDK.Api.BaseData
{
   public class getauthorizationRequest
    {
        public string appid;
        public long time;
        public string sign;
        public int sanbox = 0;

        public getauthorizationRequest(Config config)
        {
            this.appid = config.appid;
            this.time = Common.GetCurrentUnixTimestamp();
            this.sanbox = config.isSanbox ? 1 : 0;
            this.sign = this.getSign(config);
        }

        private string getSign(Config config)
        {
            string sign = Common.GetMd5Hash(Common.GetMd5Hash(this.appid + this.time) + config.appkey);
            return sign;
        }
    }
}
