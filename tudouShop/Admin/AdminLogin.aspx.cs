using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;

namespace EShop
{
    public partial class AdminLogin : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string name = tbxUserName.Text.Trim();
            string pwd = tbxPassword.Text.Trim();
            BLL.t_Admin adminLogic = new BLL.t_Admin();
            string condition = " account = '" + name + "' and pwd = '" + pwd + "'";
            DataTable dt = adminLogic.GetList(condition).Tables[0];

            if (dt.Rows.Count == 1 )
            {
                
                Response.Redirect("~/admin/ProductList.aspx");
            }
            else if(dt.Rows.Count == 0)
            {
                Alert.ShowInTop("用户名或密码错误！", MessageBoxIcon.Error);
            }
            else
            {
                Alert.ShowInTop("找到多条数据！请联系技术人员", MessageBoxIcon.Error);
            }
        }
    }
}