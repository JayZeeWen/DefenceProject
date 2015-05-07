using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using FineUI.Examples;
using EShop.BLL;
using EShop.Model;
using 土豆购物;

namespace EShop
{
    public partial class Special : System.Web.UI.Page
    {
        public string type
        {
            get
            {
                return Request.QueryString["tid"];
            }
        }

        public string ctype
        {
            get
            {
                return Request.QueryString["ctid"];
            }
        }

        public string  brand
        {
            get
            {
                return Request.QueryString["bid"];
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Bind();
            if (!string.IsNullOrEmpty(brand))
            {
                string BraName = SqlHelper.ExecuteScalar("select BraName from t_brand where BraID = " + brand).ToString();
                ltlTitle.Text = BraName;
            }
        }
        protected void Bind()
        {

            BLL.T_Products probll = new EShop.BLL.T_Products();
            string condition = " state = 0" ;//查询条件
            if (!string.IsNullOrEmpty(type))
            {
                condition += " and  CTID in (select CTID from T_CType where TID= " + type + " )";
            }
            if (!string.IsNullOrEmpty(brand))
            {
                condition += " and BraID = " + brand ;
            }
            if (!string.IsNullOrEmpty(ctype))
            {
                condition += " and CTID = " + ctype;
            }
            int totalcount = Convert.ToInt32(SqlHelper.ExecuteScalar("select count(1) from t_products where "+ condition));
            int size = 12;
            int pageIndex = 1;
            int PageCount =(int) Math.Ceiling(totalcount / Convert.ToDouble(size));
            if(!string.IsNullOrEmpty(Request.QueryString["p"]))
            {
                pageIndex = Convert.ToInt32(Request.QueryString["p"]);
            }
            SetPage(pageIndex, PageCount);
            rptProducts.DataSource = probll.GetListByPage(condition, "", pageIndex, size);

            if (string.IsNullOrEmpty(brand) && !string.IsNullOrEmpty(ctype))
            {
                rptType.DataSource = SqlHelper.ExecuteDataTable("select * from t_ctype where " + condition);
            }
            else
            {
                rptType.DataSource = SqlHelper.ExecuteDataTable("select c.CTID CTName from T_Products p  left join T_CType c on c.CTID = p.CTID where BraID = '" + brand + "' group by CTName,c.CTID"); ;
            }

            rptProducts.DataBind();
            rptType.DataBind();
        }

        #region 分页
        private void SetPage(int PageIndex, int pagecount)
        {

            ltlPage.Text = "<ul>";
            if (PageIndex != 1)
            {
                ltlPage.Text += "<li class='prev'><a href='special.aspx?tid=" + type + "&bid=" + brand + "&p=" + (PageIndex - 1) + "'><span>&#8592;</span></a></li>";
            }
            for (int i = 1; i < pagecount + 1; i++)
            {
                if (i == PageIndex)
                {
                    ltlPage.Text += "<li class='curent'><a href='special.aspx?tid=" + type + "&bid=" + brand + "&p=" + i + "'>" + i.ToString() + "</a></li>";
                }
                else
                {
                    ltlPage.Text += "<li><a href='special.aspx?tid=" + type + "&bid=" + brand + "&p=" + i + "'>" + i.ToString() + "</a></li>";
                }
            }
            if (PageIndex != pagecount && pagecount != 0)
            {
                ltlPage.Text += "<li class='next'><a href='special.aspx?tid=" + type + "&bid=" + brand + "&p=" + (PageIndex + 1) + "'>&#8594;</a></li>";
            }
            ltlPage.Text += "</ul>";

        }
        #endregion

    }
}