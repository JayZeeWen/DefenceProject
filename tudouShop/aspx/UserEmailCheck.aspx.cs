using FineUI.Examples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;
using System.Data;
using 土豆购物;
using System.Data.SqlClient;


namespace EShop
{
    public partial class UserEmailCheck : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            string activecode = Request.QueryString["activecode"];
            BLL.T_Users userlogic = new BLL.T_Users();
            if(userlogic.Exists(Convert.ToInt64(id)))
            {
                DataTable dt = SqlHelper.ExecuteDataTable("select * from t_UserActive where activecode = @activecode and userid = @userid"
                                                        , new SqlParameter("@activecode", activecode), new SqlParameter("@userid", id));
                if (dt.Rows.Count == 1)
                {
                    BLL.T_Users userbll = new BLL.T_Users();
                    Model.T_Users user = userbll.GetModel(Convert.ToInt64(id)) ;
                    user.state = 1;
                    userbll.Update(user);
                    Alert.ShowInTop("激活成功,请登录");
                }
            }
            else 
            {
                Alert.ShowInTop("不存在该用户，请联系技术人员");
            }

        }
    }
}