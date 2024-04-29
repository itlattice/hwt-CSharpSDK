using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using CSharpSDK.Lib;
using System.Net;
using System.IO;

namespace CSharpSDK.Api
{
   public class RequestBase
    {
        protected string host = "https://openapi.hwt88.cn/";

        private Config config;

        public static string token = "";
        public static int expireTime = 0;

        public string request(string action,Object data,Config config)
        {
            string json = JsonConvert.SerializeObject(data);
            string url = this.host + "/v1/request";
            this.config = config;
            if (config.isSanbox)
            {
                url += "-test";
            }
            Dictionary<string, string> header = this.getHeader();

            return this.httpRequestAsync(url,json,header);
        }

        private Dictionary<string,string> getHeader()
        {
            if(token==""||expireTime<Common.GetCurrentUnixTimestamp())
            {
                token = this.getToken();
            }
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Authorization", token);
            return headers;
        }

        private string getToken()
        {
            string url = this.host+"/v1/getauthorization";
            string data = JsonConvert.SerializeObject(new BaseData.getauthorizationRequest(this.config));
            string response=httpRequestAsync(url, data, new Dictionary<string, string>());
            BaseData.getauthorizationResponse responseObject=JsonNewtonsoft.FromJSON<BaseData.getauthorizationResponse>(response);
            if (responseObject.code != "0")
            {
                throw new Exception(responseObject.msg);
            }
            token = responseObject.authorization;
            DateTime n = Convert.ToDateTime(responseObject.expire_time);
            TimeSpan t = n - Convert.ToDateTime("1970-01-01 0:00:00");
            expireTime = t.Seconds-3600;
            return responseObject.authorization;
        }

        private string httpRequestAsync(string url,string data,Dictionary<string,string> header)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, errors) => true;
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "POST";//请求方式
            foreach(KeyValuePair<string,string> keyValue in header)
            {
                req.Headers[keyValue.Key] = keyValue.Value;
            }
            req.ContentType = "application/json; charset=UTF-8";
            byte[] json = Encoding.UTF8.GetBytes(data);
            req.ContentLength = json.Length;
            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(json, 0, json.Length);
                reqStream.Close();
            }
            HttpWebResponse response = (HttpWebResponse)req.GetResponse();  //发送请求
            Stream responseStream = response.GetResponseStream();
            StreamReader streamReader = new StreamReader(responseStream, Encoding.UTF8);//解析
            string str = streamReader.ReadToEnd();//输出
            return str;
        }
    }
}
