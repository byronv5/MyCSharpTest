using Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Security;

namespace WebTest.ajax
{
    /// <summary>
    /// 获取JsApi权限配置的数组/四个参数
    /// </summary>
    public class GetWxJsApiConfig : BaseAjax
    {

        protected override string GetAjaxResult(HttpContext context)
        {
            string timeStamp = GetTimestamp();//生成签名的时间戳
            string noncestr = GetNoncestr();//生成签名的随机串
            string page = context.Request["Pagepath"];
            string url = "http://" + context.Request.Url.Host + "/" + page;//当前的地址
            string appid = "*****";

            string jsapiTicke = GetJsapiTicket();//获取ticket
            string[] arrayList = { "jsapi_ticket=" + jsapiTicke, "timestamp=" + timeStamp, "noncestr=" + noncestr, "url=" + url };
            Array.Sort(arrayList);
            string sign = string.Join("&", arrayList);
            UnionLog.WriteLog(LogType.UNION_INFO, "加密前的签名:" + sign);
            sign = FormsAuthentication.HashPasswordForStoringInConfigFile(sign, "SHA1").ToLower();
            UnionLog.WriteLog(LogType.UNION_INFO, "加密后的签名:" + sign);
            var obj = new
            {
                appId = appid,
                timestamp = timeStamp,
                nonceStr = noncestr,
                signature = sign
            };
            string rst = JsonConvert.SerializeObject(obj);
            UnionLog.WriteLog(LogType.UNION_INFO, "JS-SDK注册wxconfig参数:" + rst);
            return rst;
        }

        /// <summary>
        /// 随机串
        /// </summary>
        public static string GetNoncestr()
        {
            Random random = new Random();
            return GetMd5(random.Next(1000).ToString(CultureInfo.InvariantCulture), "GBK").ToLower().Replace("s", "S");
        }

        /// <summary>
        /// 时间截，自1970年以来的秒数
        /// </summary>
        public static string GetTimestamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// 获取jsapi_ticket
        /// </summary>
        /// <returns></returns>
        public static string GetJsapiTicket()
        {
            string appID = "******";
            string appSecret = "******";

            string reqponesJson =
                HttpHelper.GetResponse(string.Format("http://www.motherfuck.com/wx/tokenserver/default.aspx?type=1&appid={0}&appsecret={1}", appID, appSecret));
            var ja = JsonConvert.DeserializeObject<JObject>(reqponesJson);
            if (ja != null && ja["errcode"].ToString() == "1")
            {
                return ja["jsapi_ticket"].ToString();
            }
            throw new Exception(ja["errmsg"].ToString());

        }
        /// <summary>
        /// MD5
        /// </summary>
        /// <param name="encypStr"></param>
        /// <param name="charset"></param>
        /// <returns></returns>
        public static string GetMd5(string encypStr, string charset)
        {
            MD5CryptoServiceProvider m5 = new MD5CryptoServiceProvider();

            //创建md5对象
            byte[] inputBye;

            //使用GB2312编码方式把字符串转化为字节数组．
            try
            {
                inputBye = Encoding.GetEncoding(charset).GetBytes(encypStr);
            }
            catch (Exception)
            {
                inputBye = Encoding.GetEncoding("GB2312").GetBytes(encypStr);
            }
            byte[] outputBye = m5.ComputeHash(inputBye);

            string retStr = System.BitConverter.ToString(outputBye);
            retStr = retStr.Replace("-", "").ToUpper();
            return retStr;
        }
    }
}