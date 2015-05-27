using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using FineUI.Examples;
using 土豆购物;
using EShop.BLL;
using System.Data.SqlClient;
using FineUI;

namespace EShop
{
    public partial class CheckOut : System.Web.UI.Page
    {
        long x;
        public long LoginID
        {

            get
            {
                if (Session["LoginUser"] != null)
                {
                    x = long.Parse(Session["LoginUser"].ToString());

                }
                return x;
            }
        } 
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (LoginID != 0)
            {
                BindAddressDataSource();
                BindCartDataSource();
            }
            else
            {
                ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>showtips();</script>");
            }
        }

        public void BindAddressDataSource()
        {
            if (LoginID != 0)
            {
                string strwhere = "UserID = " + LoginID.ToString();
                BLL.T_DeliveryAddress deliverbll = new T_DeliveryAddress();
                DataTable dt = deliverbll.GetList(4, strwhere, "id").Tables[0];
                if (dt.Rows.Count > 0)
                {
                    rptAddress.DataSource = dt;
                    rptAddress.DataBind();
                }
                else
                {
                    
                }
            }
        }

        public void BindCartDataSource()
        {
            int orderid = Convert.ToInt32(SqlHelper.ExecuteScalar(@"SELECT IDENT_CURRENT('T_Orders')"));
            int size = 5;
            int PageIndex = 1;
            int totalcount = Convert.ToInt32(SqlHelper.ExecuteScalar("select COUNT(*) from  OrderDetials where OrderID=@OrderID", new SqlParameter("@OrderID", orderid)));
            int pagecount = (int)Math.Ceiling(totalcount / Convert.ToDouble(size));//获得页数

            if (!string.IsNullOrEmpty(Request.QueryString["p"]))
            {
                PageIndex = Convert.ToInt32(Request.QueryString["p"]);
            }
            
            //分页查询
            rptCart.DataSource = SqlHelper.ExecuteDataTable(@"select * from (
                                                       select o.userid as  UserID ,o.OrderID,o.state, p.ProID, Quantity,ProName,Des,Price,Img ,ROW_NUMBER() over (order by p.ProID asc) as num
                                                       from OrderDetials c left join T_Orders o on c.OrderID=o.OrderID left join T_Products p on c.ProductID=p.ProID )as s  
                                                       where  UserID= @UserID and OrderID=@OrderID and s.num between @Start and @End "
                                                , new SqlParameter("@UserID", LoginID)
                                                , new SqlParameter("@OrderID", orderid)
                                                , new SqlParameter("@Start", (PageIndex - 1) * size + 1)
                                                , new SqlParameter("@End", PageIndex * size));
            //总价
            decimal money = Convert.ToDecimal(SqlHelper.ExecuteScalar(@"select SUM(s.Price*s.Quantity) from(
                                                                      select o.userid as  UserID ,o.OrderID,o.state, p.ProID, Quantity,ProName,Des,Price,Img ,ROW_NUMBER() over (order by p.ProID asc) as num
                                                       from OrderDetials c left join T_Orders o on c.OrderID=o.OrderID left join T_Products p on c.ProductID=p.ProID )as s  
                                                       where  UserID= @UserID and OrderID=@OrderID", new SqlParameter("@UserId", LoginID), new SqlParameter("@OrderID", orderid)));
            ltlTotal.Text = "$" + money;
            SetPage(PageIndex, pagecount);//分页实现
            rptCart.DataBind(); 
        }

        protected void order_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Context.Request["code"]))
            {
                int id = int.Parse(Context.Request["code"]);
                int orderid = Convert.ToInt32(SqlHelper.ExecuteScalar(@"SELECT IDENT_CURRENT('T_Orders')"));
                SqlHelper.ExecuteScalar(@"update T_Orders set Address=@Address where  OrderID= @OrderID"
                                                     , new SqlParameter("@Address", id), new SqlParameter("@OrderID", orderid));
                Response.Redirect("~/Payment.aspx");
            }
            else
            {
                Alert.ShowInTop("未选择收货地址");
            }
            
        }
       
        public void nullsession()
        {
            Confirm.Show("请先登陆");
            Response.Redirect("~/aspx/Login.aspx");
        }

        #region 分页
        private void SetPage(int PageIndex, int pagecount)
        {

            ltlPage.Text = "<ul>";
            if (PageIndex != 1)
            {
                ltlPage.Text += "<li class='prev'><a href='CheckOut.aspx?p=" + (PageIndex - 1) + "'><span>&#8592;</span></a></li>";
            }
            for (int i = 1; i < pagecount + 1; i++)
            {
                if (i == PageIndex)
                {
                    ltlPage.Text += "<li class='curent'><a href='CheckOut.aspx?p=" + i + "'>" + i.ToString() + "</a></li>";
                }
                else
                {
                    ltlPage.Text += "<li><a href='CheckOut.aspx?p=" + i + "'>" + i.ToString() + "</a></li>";
                }
            }
            if (PageIndex != pagecount)
            {
                ltlPage.Text += "<li class='next'><a href='CheckOut.aspx?p=" + (PageIndex + 1) + "'>&#8594;</a></li>";
            }
            ltlPage.Text += "</ul>";

        }
        #endregion
        // 删除购物车商品
      
    }
}