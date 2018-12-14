using System;

namespace Prototype
{
    /// <summary>
    /// 广告模板
    /// </summary>
    public class AdvTemplate
    {
        private string advSubject = $"xxx银行国庆信用卡抽奖活动,日期：{DateTime.Now}";
        private string advContext = "只要敢刷我们就敢送100w";
        public string GetAdvSubject()
        {
            return advSubject;
        }
        public string GetAdvContext()
        {
            return advContext;
        }
    }
}
