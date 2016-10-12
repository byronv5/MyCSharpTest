using System;

namespace WebTest
{
    public partial class EncipherTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Btn_Md5_Click(object sender, EventArgs e)
        {
            txt_after.Text = Common.Md5.StandardMd5(txt_before.Text);
        }
    }
}