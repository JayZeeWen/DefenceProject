﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using 土豆购物;

namespace tudouShop
{
    public partial class Orders : System.Web.UI.Page
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
                
                BindCartDataSource();
            }
            else
            {
                ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>showtips();</script>");
            }
        }
          public void BindCartDataSource()
        {
            int size = 5;
            int PageIndex = 1;
            int totalcount = Convert.ToInt32(SqlHelper.ExecuteScalar("select COUNT(*) from OrderDetials where OrderID in (select OrderID from T_Orders where UserID=@UserID)", new SqlParameter("@UserID", LoginID)));
            int pagecount = (int)Math.Ceiling(totalcount / Convert.ToDouble(size));//获得页数

            if (!string.IsNullOrEmpty(Request.QueryString["p"]))
            {
                PageIndex = Convert.ToInt32(Request.QueryString["p"]);
            }
            //分页查询
            DataTable data = SqlHelper.ExecuteDataTable(@"select * from (
                                                       select o.userid as  UserID ,o.OrderID,o.state, p.ProID, Quantity,ProName,Des,Price,Img ,ROW_NUMBER() over (order by o.OrderID asc) as num
                                                       from OrderDetials c left join T_Orders o on c.OrderID=o.OrderID left join T_Products p on c.ProductID=p.ProID )as s  
                                                       where  UserID= @UserID and s.num between @Start and @End "
                                                , new SqlParameter("@UserID", LoginID)
                                                , new SqlParameter("@Start", (PageIndex - 1) * size + 1)
                                                , new SqlParameter("@End", PageIndex * size));
           
            foreach (DataRow dr in data.Rows)
              {
                  switch (dr["state"].ToString())
                  {
                      case "0": dr["state"] = "未付款";
                          break;
                      case "1": dr["state"] = "未发货";
                          break;
                      case "2": dr["state"] = "已发货";
                          break;

                  }
              }
           
            rptorders.DataSource = data;

            
            DataTable dt = SqlHelper.ExecuteDataTable(@"select Quantity from t_Cart where UserID=@UserID", new SqlParameter("@UserID", LoginID));
            if (dt.Rows.Count != 0)
              {
                  decimal money = Convert.ToDecimal(SqlHelper.ExecuteScalar(@"select SUM(s.Price*s.Quantity) from(
                                                                       select c.Userid as UserID, Quantity,ProName,Price,Img ,ROW_NUMBER() over (order by p.ProID asc) as num
                                                                       from t_Cart c left join T_Products p on c.ProID=p.ProID )as s  
                                                                       where  UserID= @UserId", new SqlParameter("@UserId", LoginID)));
                  ltlTotal.Text = "$" + money;
              }
              else
              {
                  ltlTotal.Text = "$" +0;
              }
           
            SetPage(PageIndex, pagecount);//分页实现
            rptorders.DataBind(); 
        }
        #region 分页
        private void SetPage(int PageIndex, int pagecount)
        {

            ltlPage.Text = "<ul>";
            if (PageIndex != 1)
            {
                ltlPage.Text += "<li class='prev'><a href='Orders.aspx?p=" + (PageIndex - 1) + "'><span>&#8592;</span></a></li>";
            }
            for (int i = 1; i < pagecount + 1; i++)
            {
                if (i == PageIndex)
                {
                    ltlPage.Text += "<li class='curent'><a href='Orders.aspx?p=" + i + "'>" + i.ToString() + "</a></li>";
                }
                else
                {
                    ltlPage.Text += "<li><a href='Orders.aspx?p=" + i + "'>" + i.ToString() + "</a></li>";
                }
            }
            if (PageIndex != pagecount)
            {
                ltlPage.Text += "<li class='next'><a href='Orders.aspx?p=" + (PageIndex + 1) + "'>&#8594;</a></li>";
            }
            ltlPage.Text += "</ul>";

        }
        #endregion
    }
}