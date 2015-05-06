using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using 土豆购物;
using FineUI;
using FineUI.Examples;
using System.Data.SqlClient;

namespace EShop
{
    public partial class ShoppingCart :System.Web.UI.Page
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {
            Bind();
            AjaxPro.Utility.RegisterTypeForAjax(typeof(ShoppingCart));
        }
        void Bind()
        {
            int size = 5;
            int PageIndex = 1;
            int totalcount = Convert.ToInt32( SqlHelper.ExecuteScalar("select COUNT(*) from T_Cart where UserID=1"));
            int pagecount = (int)Math.Ceiling(totalcount / Convert.ToDouble(size));//获得页数

            if (!string.IsNullOrEmpty(Request.QueryString["p"]))
            {
                PageIndex = Convert.ToInt32(Request.QueryString["p"]);
            }
            //分页查询
            DataTable dt = SqlHelper.ExecuteDataTable(@"select * from (
                                                       select c.Userid as UserID,c.ProID, Quantity,ProName,Price,Img ,ROW_NUMBER() over (order by p.ProID asc) as num
                                                       from t_Cart c left join T_Products p on c.ProID=p.ProID )as s  
                                                       where  UserID= 1 and s.num between @Start and @End "
                                                    ,new SqlParameter("@Start",(PageIndex - 1) * size + 1)
                                                    , new SqlParameter("@End", PageIndex * size));
            //总价
            decimal money = Convert.ToDecimal(SqlHelper.ExecuteScalar(@"select SUM(s.Price*s.Quantity) from(
                                                                       select c.Userid as UserID, Quantity,ProName,Price,Img ,ROW_NUMBER() over (order by p.ProID asc) as num
                                                                       from t_Cart c left join T_Products p on c.ProID=p.ProID )as s  
                                                                       where  UserID= @UserId", new SqlParameter("@UserId", 1))
                                                    );
            ltlPrice.Text = "$" + money;
            ltlTotal.Text = "$" + money;
            SetPage(PageIndex, pagecount);//分页实现
            rptCart.DataSource = dt;
            rptCart.DataBind();
        }

        #region 分页
        private void SetPage(int PageIndex, int pagecount)
        {
            
            ltlPage.Text = "<ul>";
            if (PageIndex != 1)
            {
                ltlPage.Text += "<li class='prev'><a href='ShoppingCart.aspx?p=" + (PageIndex - 1) + "'><span>&#8592;</span></a></li>"; 
            }            
            for (int i = 1; i < pagecount+1; i++)
            {
                if (i == PageIndex)
                {
                    ltlPage.Text += "<li class='curent'><a href='ShoppingCart.aspx?p=" + i + "'>" + i.ToString() + "</a></li>";
                }
                else
                {
                    ltlPage.Text += "<li><a href='ShoppingCart.aspx?p=" + i + "'>" + i.ToString() + "</a></li>";
                }
            }
            if (PageIndex != pagecount)
            {
                ltlPage.Text += "<li class='next'><a href='ShoppingCart.aspx?p=" + (PageIndex + 1) + "'>&#8594;</a></li>";
            }
            ltlPage.Text += "</ul>";
 
        }
        #endregion



        // 删除购物车商品
        [AjaxPro.AjaxMethod]
        public bool del(int proid)
        {
            SqlHelper.ExecuteNonQuery("delete from t_cart where userid =1 and proid = @ProID",new SqlParameter("@ProID",proid));
            return true;
        }


        // 更改数量
        [AjaxPro.AjaxMethod]
        public bool Edit(int proid,int quantity)
        {
            SqlHelper.ExecuteNonQuery("update T_Cart set Quantity = @quantity where ProID = @proid and UserID = 1 "
                                    , new SqlParameter("@quantity", quantity), new SqlParameter("@proid", proid));
            return true;
 
        }
    }
}