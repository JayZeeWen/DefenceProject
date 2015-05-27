using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;
using Newtonsoft.Json.Linq;
using EShop.Model;
using EShop.BLL;

namespace tudouShop.Admin
{
    public partial class OrderInfo : System.Web.UI.Page
    {
        public string OrderId
        {
            get
            {
                return Request.QueryString["id"].ToString();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        private void BindGrid()
        {
            gridDetails.DataSource = GetSourceTable();
            gridDetails.DataBind();
        }

        private DataTable GetSourceTable()
        {
            EShop.BLL.T_Orders orderBll = new EShop.BLL.T_Orders();
            string condition = "od.OrderID =" + OrderId;
            //获取数据总条数
            gridDetails.RecordCount = orderBll.GetDetailsCount(condition);
            //获取分页数据
            DataTable dt = orderBll.GetOrderDetailsDataSet(condition, "ItemID", gridDetails.PageIndex, gridDetails.PageSize).Tables[0];

            return dt;
        }

        protected void gridDetails_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            gridDetails.PageIndex = e.NewPageIndex;
            BindGrid();
        }
    }
}