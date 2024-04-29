using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpSDK
{
    public class HwtApi
    {
        public Config config;

        public HwtApi(Config config)
        {
            this.config = config;
        }

        /// <summary>
        /// 调用基础接口
        /// </summary>
        /// <returns></returns>
        public Api.Basic Basic()
        {
            return new Api.Basic(this.config);
        }
    }
}
