using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Common.AbilityInterface
{
    /// <summary>
    /// 能力接口策略基类
    /// </summary>
    [Serializable]
    public abstract class Strategy
    {
        #region 签名模块
        /// <summary>
        /// 能力接口AppCode
        /// </summary>
        public string AppCode
        {
            get { return ConfigurationManager.AppSettings["AppCode"]; }
        }
        /// <summary>
        /// 能力接口Key
        /// </summary>
        private static string Key
        {
            get { return ConfigurationManager.AppSettings["Key"]; }
        }
        /// <summary>
        /// RequestDate
        /// </summary>
        public string RequestDate
        {
            get { return DateTime.Now.ToString("yyyyMMddHHmmss"); }
        }
        /// <summary>
        /// 生成验证签名sign
        /// </summary>
        /// <returns></returns>
        public string Sign
        {
            get
            {
                string waitSign = "AppCode=" + AppCode + "&SingKey=" + Key + "&Date=" + RequestDate;
                return Md5.StandardMd5(waitSign);
            }
        }
        #endregion
        /// <summary>
        /// 调用接口响应
        /// </summary>
        public virtual string GetResponse(Object oj)
        {
            return "";
        }
    }
}
