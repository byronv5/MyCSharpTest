using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Common
{
    public static class Md5
    {
        public static string StandardMd5(string str)
        {
            string ret = string.Empty;
            byte[] b = Encoding.UTF8.GetBytes(str);
            b = new MD5CryptoServiceProvider().ComputeHash(b);
            return b.Aggregate(ret, (current, t) => current + t.ToString("x").PadLeft(2, '0'));
        }    
    }
}
