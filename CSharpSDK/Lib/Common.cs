using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSDK.Lib
{
    class Common
    {
        public static long GetCurrentUnixTimestamp()
        {
            DateTime epochStart = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            long currentUnixTimestamp = (long)(DateTime.UtcNow - epochStart).TotalSeconds;
            return currentUnixTimestamp;
        }

        public static string GetMd5Hash(string input)
        {
            // 创建一个MD5对象
            using (MD5 md5Hash = MD5.Create())
            {
                // 将输入字符串转换为字节数组并计算其MD5哈希
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                // 创建一个新的Stringbuilder来收集字节并创建一个字符串
                StringBuilder sBuilder = new StringBuilder();

                // 循环遍历每个字节的哈希，并格式化为十六进制字符串
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }

                // 返回十六进制字符串
                return sBuilder.ToString();
            }
        }

        public static string getUUID()
        {
            Guid guid = Guid.NewGuid();
            return guid.ToString();
        }
    }
}
