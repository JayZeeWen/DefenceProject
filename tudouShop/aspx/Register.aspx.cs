using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EShop.BLL;
using FineUI.Examples;
using FineUI;
using EShop.Model;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Security.Cryptography;
using System.Web.Security;
using 土豆购物;
using System.Data.SqlClient;

namespace EShop
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtEmail.Text) && !string.IsNullOrEmpty(txtPwd1.Text))
            {
                Model.T_Users entity = new Model.T_Users();
                entity.Account = txtEmail.Text.Trim();
                entity.Pwd = txtPwd1.Text.Trim();
                entity.state = 0;
                BLL.T_Users user = new BLL.T_Users();
                string GuidCode = Guid.NewGuid().ToString();
                if (user.Add(entity))
                {
                    SendMail(txtEmail.Text.Trim(), GuidCode);                    
                    Alert.ShowInTop("注册成功，请激活邮箱！");                    
                }
                else
                {
                    Alert.ShowInParent("实例错误");
                }
            }
        }


        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="email">邮件地址</param>
        /// <param name="activeCode">激活码</param>
        private void SendMail(string email, string activeCode)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            string test = System.Text.Encoding.Unicode.GetString(//转成字符串
                md5.ComputeHash(//加密byte[]数组
                System.Text.Encoding.Unicode.GetBytes(activeCode)//得到byte[]数组
                ));
            string ActiveCode = FormsAuthentication.HashPasswordForStoringInConfigFile(test, "md5");
            
            MailMessage mailMsg = new MailMessage();
            mailMsg.From = new MailAddress("562230790@qq.com");
            mailMsg.To.Add(email);
            mailMsg.Subject = "请注册激活";
            long number = getid();

            //插入验证表数据
            SqlHelper.ExecuteNonQuery("insert into t_UserActive(activecode,userid) values(@activecode,@UserID)"
                                    ,new SqlParameter("@activecode",ActiveCode)
                                    ,new SqlParameter("@userID",number));

            StringBuilder contentBuilder = new StringBuilder();
            contentBuilder.Append("请单击以下链接完成激活<br/>");
            string url = "localhost:50184/aspx/UserEmailCheck.aspx?activecode=" + ActiveCode + "&id=" + number;
            contentBuilder.Append("<a href='//localhost:50184/aspx/UserEmailCheck.aspx?activecode=" + ActiveCode + "&id=" + number + "'>" + url + "</a>");
            mailMsg.Body = contentBuilder.ToString();
            mailMsg.IsBodyHtml = true;
            SmtpClient client = new SmtpClient();
            client.Host = "smtp.qq.com";
            client.Port = 25;
            NetworkCredential credential = new NetworkCredential();
            credential.UserName = "562230790";
            credential.Password = "windszwj5515095";
            client.Credentials = credential;
            try
            {
                client.Send(mailMsg);
            }
            catch (SmtpFailedRecipientException ex)
            {
                Alert.ShowInTop(ex.ToString());
                Response.End();
            }
        }

        private long getid()
        {
            long id = Convert.ToInt64( SqlHelper.ExecuteScalar("select MAX(UserID) from t_users"));
            return id;
        }
    }
}