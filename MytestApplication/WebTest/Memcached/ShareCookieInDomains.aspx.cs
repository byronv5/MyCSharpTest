using System;
using System.Configuration;
using Common;
using Memcached.ClientLibrary;

namespace WebTest
{
    public partial class ShareCookieInDomains : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region cookie操作
        /// <summary>
        /// 设置cookie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_setcookie_click(object sender, EventArgs e)
        {
            CookieHelper.SetCookie("TestCookie", "hello,cookie", 1, TimeType.M);
        }
        /// <summary>
        /// 获取cookie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_getcookie_click(object sender, EventArgs e)
        {
            var t = CookieHelper.GetCookie("TestCookie");
            Response.Write("获取到的cookie为：" + t);
        }
        /// <summary>
        /// 删除cookie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_removecookie_click(object sender, EventArgs e)
        {
            CookieHelper.RemoveCookie("TestCookie");
        }
        #endregion

        #region memcache操作
        /// <summary>
        /// 设置cache
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_setcache_click(object sender, EventArgs e)
        {
            MemcachedClient cache = new MemcachedClient();
            //获取负载服务器集合
            string[] serverlist = OperateParam.SplitByComma(ConfigurationManager.AppSettings["MemCacheServers"]);
            //初始化池
            SockIOPool pool = SockIOPool.GetInstance();
            pool.SetServers(serverlist);
            pool.Initialize();        
            cache.Set("TestCache", "hello，memcache", DateTime.Now.AddMinutes(2));
        }
        /// <summary>
        /// 获取cache
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_getcache_click(object sender, EventArgs e)
        {
            MemcachedClient cache = new MemcachedClient();
            //获取负载服务器集合
            string[] serverlist = OperateParam.SplitByComma(ConfigurationManager.AppSettings["MemCacheServers"]);
            //初始化池
            SockIOPool pool = SockIOPool.GetInstance();
            pool.SetServers(serverlist);
            pool.Initialize();      
            var getCache = cache.Get("TestCache");//获取cache
            Response.Write("获取到的cache为:" + getCache);
        }
        /// <summary>
        /// 删除cache
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_removecache_click(object sender, EventArgs e)
        {
            MemcachedClient cache = new MemcachedClient();
            //获取负载服务器集合
            string[] serverlist = OperateParam.SplitByComma(ConfigurationManager.AppSettings["MemCacheServers"]);
            //初始化池
            SockIOPool pool = SockIOPool.GetInstance();
            pool.SetServers(serverlist);
            pool.Initialize();      
            cache.Delete("TestCache");//删除cache
        }
        #endregion
    }
}