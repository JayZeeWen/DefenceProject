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
            BLL.T_DeliveryAddress deliverbll = new T_DeliveryAddress();
            rptAddress.DataSource = deliverbll.GetList(4, "", "id");
            rptAddress.DataBind(); 
        }

        public void BindCartDataSource()
        {
            int size = 5;
            int PageIndex = 1;
            int totalcount = Convert.ToInt32(SqlHelper.ExecuteScalar("select COUNT(*) from T_Cart where UserID=@UserID", new SqlParameter("@UserID", LoginID)));
            int pagecount = (int)Math.Ceiling(totalcount / Convert.ToDouble(size));//获得页数

            if (!string.IsNullOrEmpty(Request.QueryString["p"]))
            {
                PageIndex = Convert.ToInt32(Request.QueryString["p"]);
            }
            //分页查询
            rptCart.DataSource = SqlHelper.ExecuteDataTable(@"select * from (
                                                       select c.Userid as UserID,c.ProID, Quantity,ProName,Des,Price,Img ,ROW_NUMBER() over (order by p.ProID asc) as num
                                                       from t_Cart c left join T_Products p on c.ProID=p.ProID )as s  
                                                       where  UserID= @UserID and s.num between @Start and @End "
                                                    , new SqlParameter("@UserID", LoginID)
                                                    , new SqlParameter("@Start", (PageIndex - 1) * size + 1)
                                                    , new SqlParameter("@End", PageIndex * size));
            //总价
            decimal money = Convert.ToDecimal(SqlHelper.ExecuteScalar(@"select SUM(s.Price*s.Quantity) from(
                                                                       select c.Userid as UserID, Quantity,ProName,Price,Img ,ROW_NUMBER() over (order by p.ProID asc) as num
                                                                       from t_Cart c left join T_Products p on c.ProID=p.ProID )as s  
                                                                       where  UserID= @UserId", new SqlParameter("@UserId", LoginID)));
            ltlTotal.Text = "$" + money;
            SetPage(PageIndex, pagecount);//分页实现
            rptCart.DataBind(); 
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

        

    }
}