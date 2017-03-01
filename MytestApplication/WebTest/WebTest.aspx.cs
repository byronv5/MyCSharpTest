using System;
using Common.AbilityInterface;
using Common.AbilityInterface.InterfaceLibrary;
using Newtonsoft.Json.Linq;
using Exceptionless;

namespace WebTest
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Btn_test_Click(object sender, EventArgs e)
        {
            try
            {
                //查询客户信息--能力接口
                Customer reqCustomer = new Customer
                {
                    DeviceNo = "18101767389",
                    DeviceType = "18"
                };
                Context ct = new Context(reqCustomer);
                string rst = ct.Excute();//返回结果为json
                JObject jObject = JObject.Parse(rst);//反序列化为object
                if (jObject["ErrCode"].ToString() != "0000")
                {
                    throw new ApplicationException(jObject["ErrMsg"].ToString());
                }                
            }
            catch (Exception ex)
            {
                ex.ToExceptionless().Submit();//提交异常到ExceptionLess
            }         
        }
    }
}