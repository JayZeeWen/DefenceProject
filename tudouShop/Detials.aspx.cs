using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EShop.Model;
using 土豆购物;
using FineUI;
using FineUI.Examples;
using System.Data.SqlClient;

namespace EShop
{
    public partial class Detials : System.Web.UI.Page
    {
        private T_Products product
        {
            get
            {
                long proid = Convert.ToInt64(Request.QueryString["ProID"]);
                BLL.T_Products probll = new BLL.T_Products();
                return probll.GetModel(proid);
            }
        }
        private T_Users loginUser
        {
            get
            {
                BLL.T_Users userbll = new BLL.T_Users();
                if (Session["LoginUser"] != null)
                {
                    return userbll.GetModel(Convert.ToInt64(Session["LoginUser"]));
                }
                else
                {
                    return null;
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                #region 设置字段显示
                lblPrice.Text = "$"+ product.Price.ToString();
                lblTitle.Text = product.ProName;
                lblPoint.Text = product.SalePoint.ToString();
                lblDesc.Text = product.Des;
                lblOldPrice.Text = "$" + product.Price.ToString();
                ImgProduct.ImageUrl = product.Img;
                #endregion
            }
        }

        protected void btnCheckOut_Click(object sender, EventArgs e)
        {
            if (loginUser != null)
            {
                if (product != null)
                {
                    SqlHelper.ExecuteNonQuery("insert into t_Cart(UserID,ProID,Quantity) values(@UserID,@ProID,@Quantity)"
                        , new SqlParameter("@UserID", loginUser.UserID)
                        , new SqlParameter("@ProID", product.ProID)
                        , new SqlParameter("Quantity", 1));
                    Alert.ShowInTop("添加购物车成功");
                }
                else
                {
                    Alert.ShowInTop("商品不能为空");
                }
            }
            else
            {
                Alert.ShowInTop("用户未登陆");   
            }
        }
    }
}