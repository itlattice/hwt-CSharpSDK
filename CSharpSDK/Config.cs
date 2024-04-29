using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSDK
{
    public class Config
    {
        public string appid = "";
        public string appkey = "";
        public bool isSanbox = false;
        public bool getnew = false;

        public Config(string appid, string appkey, bool sanBox=false, bool getnew = false)
        {
            this.appid = appid;
            this.appkey = appkey;
            this.isSanbox = sanBox;
            this.getnew = getnew;
        }
    }
}
