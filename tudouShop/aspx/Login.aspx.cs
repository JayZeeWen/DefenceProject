using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using 土豆购物;
using FineUI.Examples;
using FineUI;

namespace EShop
{
    public partial class WebForm1 :System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitCaptchaCode();
            }
        }

        private void InitCaptchaCode()
        {
            // 创建一个 6 位的随机数并保存在 Session 对象中
            Session["CaptchaImageText"] = GenerateRandomCode();
            imgCaptcha.ImageUrl = "~/captcha/captcha.ashx?w=150&h=30&t=" + DateTime.Now.Ticks;
        }

        private string GenerateRandomCode()
        {
            string s = String.Empty;
            Random random = new Random();
            for (int i = 0; i < 6; i++)
            {
                s += random.Next(10).ToString();
            }
            return s;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string name = Context.Request["txtEmail"];
            string pwd = Context.Request["txtPwd"];
            string captcha = Session["CaptchaImageText"].ToString();
            if (tbxCaptcha.Text != captcha)
            {
                Alert.ShowInTop("验证码错误！");
                InitCaptchaCode();
                return;
            }
            DataTable dt = SqlHelper.ExecuteDataTable("select * from t_Users where account =@account and Pwd = @pwd"
                                                    , new SqlParameter("@account", name), new SqlParameter("@pwd", pwd));
            if (dt.Rows.Count == 1)
            {
                if (dt.Rows[0]["state"].ToString() == "1")
                {
                    Session["LoginUser"] = dt.Rows[0][0].ToString();
                    Response.Redirect("~/index.ashx");
                    
                }
                else
                {
                    Alert.ShowInTop("用户未激活");
                }
                
            }
            else if (dt.Rows.Count == 0)
            {
                lblerror.Text = "用户名或密码错误";
                InitCaptchaCode();
            }
            else
            {
                Alert.ShowInTop("找到多条数据，请联系技术人员");
            }
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            InitCaptchaCode();
        }
    }
}