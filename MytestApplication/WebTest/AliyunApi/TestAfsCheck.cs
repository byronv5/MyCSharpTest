using System;
using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Profile;
using Aliyun.Acs.Jaq.Model.V20161123;
using System.Web;

namespace WebTest.AliyunApi
{
    /// <summary>
    /// 用于Web端的拦截
    /// </summary>
    public class TestAfsCheck
    {
        IAcsClient client = null;
        public TestAfsCheck()
        { 
            IClientProfile profile = DefaultProfile.GetProfile("cn-hangzhou", "LTAI0ZGcQM3K2jWj", "vBD6vbxKwynGlDAZPA0JuPDfdcouo9");
            client = new DefaultAcsClient(profile);
            DefaultProfile.AddEndpoint("cn-hangzhou", "cn-hangzhou", "jaq", "jaq.aliyuncs.com");
        }
        public void Test()
        {
            AfsCheckRequest request = new AfsCheckRequest();
            request.Platform = 3;//必填参数，请求来源： 1：Android端； 2：iOS端； 3：PC端及其他
            request.Session = HttpContext.Current.Request.Form["csessionid"];// 必填参数，从前端获取，不可更改
            request.Sig = HttpContext.Current.Request.Form["sig"];// 必填参数，从前端获取，不可更改
            request.Token = HttpContext.Current.Request.Form["token"];// 必填参数，从前端获取，不可更改
            request.Scene = HttpContext.Current.Request.Form["scene"];// 必填参数，从前端获取，不可更改
            try
            {
                AfsCheckResponse response = client.GetAcsResponse(request);
                // TODO
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}