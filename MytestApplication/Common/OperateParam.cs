using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public static class OperateParam
    {
        /// <summary>
        /// 根据逗号将字符串拆分成数组
        /// </summary>
        /// <param name="strIn"></param>
        /// <returns></returns>
        public static string[] SplitByComma(string strIn)
        {
            if (!string.IsNullOrEmpty(strIn))
            {
                return strIn.Split(',');
            }
            return null;
        }
    }
}
