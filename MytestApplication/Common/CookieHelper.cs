using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace Common
{
    public static class CookieHelper
    {
        #region Cookies操作
        #region 设置cookie
        /// <summary>
        /// 设置cookie
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expires"></param>
        /// <param name="timeType"></param>
        public static bool SetCookie(string key, string value, int expires, Enum timeType)
        {
            try
            {
                var cookie = new HttpCookie(key) {Value = value};
                if (Equals(timeType, TimeType.D))
                    cookie.Expires = DateTime.Now.AddDays(expires);               
                else if (Equals(timeType, TimeType.H))
                    cookie.Expires = DateTime.Now.AddHours(expires);
                else if (Equals(timeType, TimeType.M))
                    cookie.Expires = DateTime.Now.AddMinutes(expires);
                //cookie.Domain = ".ct10000.com";//当要跨域名访问的时候,给cookie指定域名即可,格式为.xxx.com
                HttpContext.Current.Response.AppendCookie(cookie);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion
        #region 移除cookie
        /// <summary>
        /// 移除cookie
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool RemoveCookie(string key)
        {
            try
            {
                var cookie = new HttpCookie(key) { Expires = DateTime.Now.AddDays(-1) };
                HttpContext.Current.Response.Cookies.Add(cookie);
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion
        #region 获取cookie
        /// <summary>
        /// 获取cookie
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetCookie(string key)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[key];
            if (cookie != null)
            {
                return cookie.Value.ToString(CultureInfo.InvariantCulture);
            }
            return null;
        }
        #endregion
        #endregion

        #region 格式转化
        /// <summary>t
        /// 
        /// String 转成 Int
        /// </summary>
        public static int StrToInt(string inStr)
        {
            int outInt;
            int.TryParse(inStr, out outInt);
            return outInt;
        }
        /// <summary>
        /// 转化成时间类型 - 修改后增加对yyyyMMddHHmmss格式的支持
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime StrToDateTime(string date)
        {
            DateTime outdate;
            if (string.IsNullOrEmpty(date))
            {
                //return DateTime.MinValue;
                return Convert.ToDateTime("1900-1-1");
            }
            else
            {
                if (date.Length == 14 && IsNum(date))
                {
                    date = string.Format("{0}-{1}-{2} {3}:{4}:{5}", date.Substring(0, 4), date.Substring(4, 2), date.Substring(6, 2), date.Substring(8, 2), date.Substring(10, 2), date.Substring(12, 2));
                }
                else if (date.Length == 8 && IsNum(date))
                {
                    date = string.Format("{0}-{1}-{2}", date.Substring(0, 4), date.Substring(4, 2), date.Substring(6, 2));
                }
                DateTime.TryParse(date, out outdate);
                return outdate;
            }
        }
        public static string StrToDateTime2(string date)
        {
            DateTime dt = StrToDateTime(date);
            return dt.Date.ToShortDateString();
        }
        /// <summary>
        /// 格式化浮点型
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static string FormatFloat(object num)
        {
            return string.Format("{0:0.00}", num);
        }
        /// <summary>
        /// 尝试转成浮点型
        /// </summary>
        /// <param name="flo"></param>
        /// <returns></returns>
        public static float StrToFloat(string flo)
        {
            float outFloat;
            float.TryParse(flo, out outFloat);
            return outFloat;
        }
        /// <summary>
        /// 尝试转成双精度浮点型
        /// </summary>
        /// <param name="dou"></param>
        /// <returns></returns>
        public static double StrToDouble(string dou)
        {
            float outDouble;
            float.TryParse(dou, out outDouble);
            return outDouble;
        }
        /// <summary>
        /// 字符型转成十进制
        /// </summary>
        /// <param name="dec"></param>
        /// <returns></returns>
        public static decimal StrToDecimal(string dec)
        {
            decimal outDecimal;
            decimal.TryParse(dec, out outDecimal);
            return outDecimal;
        }
        /// <summary>
        /// 字符串转化成布朗值
        /// </summary>
        /// <param name="dec"></param>
        /// <returns></returns>
        public static bool StrToBool(string dec)
        {
            bool outBool;
            bool.TryParse(dec, out outBool);
            return outBool;
        }

        #endregion
        #region 判断输入类型
        /// <summary>
        /// 判断输入是否是数字
        /// </summary>
        /// <param name="str"></param>
        /// <returns>返回:True/False</returns>
        public static bool IsNum(object str)
        {
            foreach (char sbit in str.ToString())
            {
                if (sbit < '0' || sbit > '9') return false;
            }
            return true;
        }
        /// <summary>
        /// 判断输入是否是日期格式
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static bool IsDateTime(object o)
        {
            DateTime dt = new DateTime();
            if (DateTime.TryParse(o.ToString(), out dt))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 判断舒服是否正浮点数
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsPositiveFloat(object str)
        {
            if (str == null)
                return false;
            System.Text.RegularExpressions.Regex Regexp = new System.Text.RegularExpressions.Regex("^[1-9]\\d*.\\d*|0.\\d*[1-9]\\d*|0?.0+|0$");
            return Regexp.IsMatch(str.ToString()) ? true : false;
        }
        /// <summary>
        /// 用正则方式验证过滤字符串
        /// </summary>
        /// <param name="str">被验证的字符串</param>
        /// <param name="regexStr">正则规则</param>
        /// <returns>返回全部结果的拼接</returns>
        public static string FilterSafeStr(string str, string regexStr)
        {
            string result = "";
            if (string.IsNullOrEmpty(str) || string.IsNullOrEmpty(regexStr))
            {
                return result;
            }
            Regex reg = new Regex(regexStr);
            MatchCollection matchs = reg.Matches(str);
            foreach (Match m in matchs)
            {
                result += m.Value;
            }
            return result;
        }

        public static string filterSpecChar(string str)
        {
            string strs = str;
            if (strs != "" && strs != null)
            {
                strs.ToLower();
                strs = strs.Replace("xp_", "no");
                strs = strs.Replace(" ", "");
                strs = strs.Replace("'", "");
                strs = strs.Replace("=", "");
                strs = strs.Replace("%", "");
                strs = strs.Replace("<", "");
                strs = strs.Replace(">", "");
                strs = strs.Replace("(", "");
                strs = strs.Replace(")", "");
                strs = strs.Replace("/", "");
                strs = strs.Replace(@"\", "");
                strs = strs.Replace("<", "");
                strs = strs.Replace(">", "");
                strs = strs.Replace("+", "");
                strs = strs.Replace("&", "");
                strs = strs.Replace("#", "");
                strs = strs.Replace("-", "");
                strs = strs.Replace("*", "");
            }
            else
            {
                strs = "";
            }
            return strs.Trim();
        }
        /// <summary>
        /// 过滤参数,防止SQL语句注入gxb
        /// </summary>
        /// <param name="strSql">string</param>
        /// <returns> string</returns>
        public static string filterSql(string str)
        {
            string strs = str;
            if (strs != "" && strs != null)
            {
                strs.ToLower();
                strs = strs.Replace(@"exec", "-");
                strs = strs.Replace("master", "-");
                strs = strs.Replace("truncate", "-");
                strs = strs.Replace("declare", "-");
                strs = strs.Replace("create", "-");
                strs = strs.Replace("xp_", "-");
                strs = strs.Replace(" ", "-");
                strs = strs.Replace("'", "-");
                strs = strs.Replace("=", "-");
                strs = strs.Replace("%", "-");
                strs = strs.Replace("<", "-");
                strs = strs.Replace(">", "-");
                strs = strs.Replace("(", "-");
                strs = strs.Replace(")", "-");
                strs = strs.Replace("/", "-");
                strs = strs.Replace(@"\", "-");
                strs = strs.Replace("<br>", "-");
                strs = strs.Replace("insert", "-");
                strs = strs.Replace("update", "-");
                strs = strs.Replace("select", "-");
                strs = strs.Replace("delete", "-");
                strs = strs.Replace("<>", "-");
                strs = strs.Replace("in", "-");
                strs = strs.Replace("or", "-");
                strs = strs.Replace("and", "-");
                strs = strs.Replace("not", "-");
                strs = strs.Replace("+", "-");
                strs = strs.Replace("&", "-");
                strs = strs.Replace("&lt", "-");
                strs = strs.Replace("&gt", "-");
                strs = strs.Replace("&#39", "-");
                strs = strs.Replace("--", "-");
                strs = strs.Replace("*", "-");
                strs = strs.Replace("&", "-");
            }
            else
            {
                strs = "";
            }
            return strs.Trim();
        }

        #endregion
        #region 截取字符串
        /// <summary>
        /// 截取字符串,返回"aaa..."的形式，不分中英文
        /// </summary>
        /// <param name="OldStr"></param>
        /// <param name="Length"></param>
        /// <returns></returns>
        public static string CutString(string OldStr, int Length)
        {
            if (!string.IsNullOrEmpty(OldStr))
            {
                return OldStr.Length > Length ? OldStr.Substring(0, Length) + "..." : OldStr;
            }
            else
            {
                return OldStr;
            }
        }
        /// <summary>
        /// 截取字符串,返回"aaa..."的形式，区分中英文宽度，按字节
        /// </summary>
        /// <param name="OldStr"></param>
        /// <param name="Length"></param>
        /// <returns></returns>
        public static string GetSubString(string OldStr, int Length)
        {
            if (string.IsNullOrEmpty(OldStr)) return "";
            //if (Length >= OldStr.Length*2) return OldStr;
            string returnStr = "";
            bool isSub = false;
            int strLen;
            ASCIIEncoding n = new ASCIIEncoding();
            byte[] b = n.GetBytes(OldStr);
            int l = 0;     //   l   为字符串之实际长度  
            for (int i = 0; i <= b.Length - 1; i++)
            {
                if (b[i] == 63)     //判断是否为汉字或全脚符号  
                {
                    l++;
                }
                l++;
                if ((isSub == false) && ((l == Length) || ((l + 1) == Length)))
                {
                    returnStr = OldStr.Substring(0, i + 1);
                    isSub = true;
                }
            }

            strLen = l;
            if (returnStr == "")
            {
                returnStr = OldStr;
            }
            return returnStr;
        }
        #endregion
    }
    /// <summary>
    /// 时间类型-天、时、分
    /// </summary>
    public enum TimeType
    {
        D,
        H,
        M
    }
}
