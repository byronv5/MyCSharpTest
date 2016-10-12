using System.Configuration;
using Newtonsoft.Json;

namespace Common.AbilityInterface.InterfaceLibrary
{
    /// <summary>
    /// 查询客户信息
    /// </summary>
    public class Customer : Strategy
    {
        #region 属性赋初始值
        public Customer()
        {
            Password = "";
            MsCode = "";
            LoginType = "3";
            ProvinceId = "35";
        }
        #endregion
        #region 属性（接口请求参数）
        /// <summary>
        /// 设备号
        /// </summary>
        public string DeviceNo { get; set; }
        /// <summary>
        /// 登录密码（非必填)
        /// </summary>
        public string Password { get; set; }//private属性不被序列化,所以要public
        /// <summary>
        /// 登录随机码（非必填）
        /// </summary>
        private string MsCode { get; set; }

        /// <summary>
        /// 1.手机号密码登录；2.随机码登录；3.自动登录
        /// </summary>
        public string LoginType { get; set; }
        /// <summary>
        /// 设备类型
        /// </summary>
        public string DeviceType { get; set; }

        /// <summary>
        /// 省编号
        /// </summary>
        public string ProvinceId { get; set; }        
        #endregion
        #region 调用接口方法
        /// <summary>
        /// 获取能力接口返回结果
        /// </summary>
        /// <param name="st">请求的实体对象</param>
        /// <returns></returns>
        public override string GetResponse(object st)
        {
            return HttpHelper.HttpJsonPost(ConfigurationManager.AppSettings["YjfApiBaseUrl"] + "UserManage/GetLoadAuth", JsonConvert.SerializeObject(st));
        }
        #endregion
    }
}
