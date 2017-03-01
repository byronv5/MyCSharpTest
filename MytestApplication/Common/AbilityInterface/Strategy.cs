using System;
using System.Configuration;

namespace Common.AbilityInterface
{
    /// <summary>
    /// 能力接口策略基类
    /// </summary>
    [Serializable]
    public abstract class Strategy
    {
        public Strategy()
        {
            RequestDate = DateTime.Now.ToString("yyyyMMddHHmmss");
        }
        #region 签名模块
        /// <summary>
        /// 能力接口AppCode
        /// </summary>
        public string AppCode => ConfigurationManager.AppSettings["AppCode"];
        /// <summary>
        /// 能力接口Key
        /// </summary>
        private static string Key => ConfigurationManager.AppSettings["Key"];
        /// <summary>
        /// RequestDate
        /// </summary>
        public string RequestDate { get; }
        /// <summary>
        /// 签名
        /// </summary>
        public object Sign { get; internal set; }
        #endregion
        /// <summary>
        /// 调用接口响应
        /// </summary>
        public virtual string GetResponse(object oj)
        {
            return "";
        }
    }
}
