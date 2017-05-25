using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebTest.AliyunApi
{
    public partial class AliVerify : System.Web.UI.Page
    {
        TestAfsCheck ck = new TestAfsCheck();
        protected long strTimeStamp = GetTimeStamp();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Request.Form["csessionid"] != null)
            {
                ck.Test();
            }
        }
        /// <summary>  
        /// 获取时间戳(小时级别)  
        /// </summary>  
        /// <returns></returns>  
        public static long GetTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalHours);
        }
    }
}