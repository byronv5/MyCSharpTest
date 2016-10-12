using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace Common
{
    public class HttpHelper
    {
        /// <summary>
        /// http post(json)
        /// </summary>
        /// <param name="posturl"></param>
        /// <param name="postData"></param>
        /// <returns></returns>
        public static string HttpJsonPost(string posturl, string postData)
        {
            string content = string.Empty;
            Stream instream = null;
            StreamReader sr = null;
            Encoding encoding = Encoding.UTF8;
            UnionLog.WriteLog(LogType.UNION_INFO, string.Format("Http Post请求链接{0}；Post Data:{1}", posturl, postData));
            byte[] data = encoding.GetBytes(postData);
            try
            {
                // 设置参数
                HttpWebRequest request = WebRequest.Create(posturl) as HttpWebRequest;
                CookieContainer cookieContainer = new CookieContainer();
                if (request != null)
                {
                    request.CookieContainer = cookieContainer;
                    request.AllowAutoRedirect = true;
                    request.Method = "POST";
                    request.ContentType = "application/json; charset=utf-8";
                    request.ContentLength = data.Length;
                    Stream outstream = request.GetRequestStream();
                    outstream.Write(data, 0, data.Length);
                    outstream.Close();
                    Stopwatch watch = new Stopwatch();//计时器
                    watch.Start();
                    //发送请求并获取相应回应数据
                    HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                    watch.Stop();
                    //直到request.GetResponse()程序才开始向目标网页发送Post请求
                    if (response != null) instream = response.GetResponseStream();
                    if (instream != null) sr = new StreamReader(instream, encoding);
                    //返回结果网页（html）代码
                    if (sr != null)
                    {
                        content = sr.ReadToEnd();
                        UnionLog.WriteLog(LogType.UNION_INFO, string.Format("Http Post请求返回:{0}-耗时{1}毫秒", content, watch.ElapsedMilliseconds));
                        return content;
                    }
                }
                return content;
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                UnionLog.WriteLog(LogType.UNION_ERROR, string.Format("Http Post请求异常：{0}；堆栈信息：{1}", err, ex.StackTrace));
                return string.Empty;
            }
        }
        /// <summary>
        /// http post(form)
        /// </summary>
        /// <param name="posturl"></param>
        /// <param name="postData"></param>
        /// <returns></returns>
        public static string HttpFormPost(string posturl, string postData)
        {
            string content = string.Empty;
            Stream instream = null;
            StreamReader sr = null;
            Encoding encoding = Encoding.UTF8;
            UnionLog.WriteLog(LogType.UNION_INFO, string.Format("Http Post请求链接{0}；Post Data:{1}", posturl, postData));
            byte[] data = encoding.GetBytes(postData);
            try
            {
                // 设置参数
                HttpWebRequest request = WebRequest.Create(posturl) as HttpWebRequest;
                CookieContainer cookieContainer = new CookieContainer();
                if (request != null)
                {
                    request.CookieContainer = cookieContainer;
                    request.AllowAutoRedirect = true;
                    request.Method = "POST";
                    request.Accept = "text/html";
                    request.ContentType = "application/x-www-form-urlencoded; charset=utf-8";
                    request.ContentLength = data.Length;
                    Stream outstream = request.GetRequestStream();
                    outstream.Write(data, 0, data.Length);
                    outstream.Close();
                    Stopwatch watch = new Stopwatch();//计时器
                    watch.Start();
                    //发送请求并获取相应回应数据
                    HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                    watch.Stop();
                    //直到request.GetResponse()程序才开始向目标网页发送Post请求
                    if (response != null) instream = response.GetResponseStream();
                    if (instream != null) sr = new StreamReader(instream, encoding);
                    //返回结果网页（html）代码
                    if (sr != null)
                    {
                        content = sr.ReadToEnd();
                        UnionLog.WriteLog(LogType.UNION_INFO, string.Format("Http Post请求返回:{0}-耗时{1}毫秒", content, watch.ElapsedMilliseconds));
                        return content;
                    }
                }
                return content;
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                UnionLog.WriteLog(LogType.UNION_ERROR, string.Format("Http Post请求异常：{0}；堆栈信息：{1}", err, ex.StackTrace));
                return string.Empty;
            }
        }
        /// <summary>
        /// http post(xml)
        /// </summary>
        /// <param name="posturl"></param>
        /// <param name="postData"></param>
        /// <returns></returns>
        public static string HttpXmlPost(string posturl, string postData)
        {
            string content = string.Empty;
            Stream instream = null;
            StreamReader sr = null;
            Encoding encoding = Encoding.UTF8;
            UnionLog.WriteLog(LogType.UNION_INFO, string.Format("Http Post请求链接{0}；Post Data:{1}", posturl, postData));
            byte[] data = encoding.GetBytes(postData);
            try
            {
                // 设置参数
                HttpWebRequest request = WebRequest.Create(posturl) as HttpWebRequest;
                CookieContainer cookieContainer = new CookieContainer();
                if (request != null)
                {
                    request.CookieContainer = cookieContainer;
                    request.AllowAutoRedirect = true;
                    request.Method = "POST";
                    request.ContentType = "application/xml";
                    request.ContentLength = data.Length;
                    Stream outstream = request.GetRequestStream();
                    outstream.Write(data, 0, data.Length);
                    outstream.Close();
                    Stopwatch watch = new Stopwatch();//计时器
                    watch.Start();
                    //发送请求并获取相应回应数据
                    HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                    watch.Stop();
                    //直到request.GetResponse()程序才开始向目标网页发送Post请求
                    if (response != null) instream = response.GetResponseStream();
                    if (instream != null) sr = new StreamReader(instream, encoding);
                    //返回结果网页（html）代码
                    if (sr != null)
                    {
                        content = sr.ReadToEnd();
                        UnionLog.WriteLog(LogType.UNION_INFO, string.Format("Http Post请求返回:{0}-耗时{1}毫秒", content, watch.ElapsedMilliseconds));
                        return content;
                    }
                }
                return content;
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                UnionLog.WriteLog(LogType.UNION_ERROR, string.Format("Http Post请求异常：{0}；堆栈信息：{1}", err, ex.StackTrace));
                return string.Empty;
            }
        }

        public static string GetResponse(string url)
        {
            UnionLog.WriteLog(LogType.UNION_INFO, "HTPP的GET请求url:" + url);
            try
            {
                CookieContainer cookieContainer = new CookieContainer();
                var req = (HttpWebRequest)WebRequest.Create(url);
                req.KeepAlive = true;
                req.Method = "GET";
                req.AllowAutoRedirect = true;
                req.CookieContainer = cookieContainer;
                req.ContentType = "application/x-www-form-urlencoded";
                req.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,**;q=0.8";
                req.Timeout = 50000;
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var res = (HttpWebResponse)req.GetResponse();
                watch.Stop();
                using (Stream s = res.GetResponseStream())
                {
                    var reader = new StreamReader(s, Encoding.UTF8);
                    string hg = reader.ReadToEnd();
                    UnionLog.WriteLog(LogType.UNION_INFO, string.Format("HTPP的GET请求返回:{0}。耗时：{1}毫秒", hg, watch.ElapsedMilliseconds));
                    return hg;
                }
            }
            catch (Exception ex)
            {
                UnionLog.WriteLog(LogType.UNION_INFO, "HTPP的GET请求返回异常:" + ex.Message);
                return null;
            }
        }
    }
}
