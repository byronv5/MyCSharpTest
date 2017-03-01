
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;

namespace Common.AbilityInterface
{
    /// <summary>
    /// 策略引用类
    /// </summary>
    public class Context
    {        
        readonly Strategy _strategy;

        /// <summary>
        /// 构造指向不同的策略类
        /// </summary>
        /// <param name="strategy"></param>
        public Context(Strategy strategy)
        {
            this._strategy = strategy;
        }

        /// <summary>
        /// 分发到不同的策略(调用不同的接口)
        /// </summary>
        /// <returns>json</returns>
        public string Excute()
        {
            #region 签名重写
            #region 反射实例
            Type t = _strategy.GetType();//获得该类的Type
            var dicContainer = new Dictionary<string, string>();
            dicContainer.Add("SignKey", ConfigurationManager.AppSettings["SmsSignKey"]);
            //遍历成员属性
            foreach (PropertyInfo pi in t.GetProperties())
            {

                object val = pi.GetValue(_strategy, null);//用pi.GetValue获得值
                if (val != null)
                    if (val.ToString() != "")
                        dicContainer.Add(pi.Name, val.ToString());
            }
            #endregion          
            #region 动态生成签名

            dicContainer = dicContainer.OrderBy(o => o.Key).ToDictionary(o => o.Key.ToLower(), p => p.Value);
            string parameter = dicContainer.Aggregate(string.Empty, (current, item) => current + (item.Key + "=" + item.Value + "&"));
            _strategy.Sign = Md5.StandardMd5(parameter.Trim('&'));
            #endregion
            #endregion
            return _strategy.GetResponse(_strategy);
        }
    }
}
