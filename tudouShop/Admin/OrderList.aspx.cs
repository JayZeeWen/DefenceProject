using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;
using Newtonsoft.Json.Linq;
using System.Data;

namespace tudouShop.Admin
{
    public partial class OrderList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AjaxPro.Utility.RegisterTypeForAjax(typeof(OrderList));
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        private void BindGrid()
        {
            Grid1.DataSource = GetSourceTable();
            Grid1.DataBind();
        }

        private DataTable GetSourceTable()
        {
            EShop.BLL.T_Orders orderBll = new EShop.BLL.T_Orders();
            string condition = "";
            //获取数据总条数
            Grid1.RecordCount = orderBll.GetRecordCount(condition);
            //获取分页数据
            DataTable dt = orderBll.GetOrderDataSet(condition ,"OrderDate", Grid1.PageIndex, Grid1.PageSize).Tables[0];

            return dt;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

        }

        protected void Grid1_PageIndexChange(object sender, GridPageEventArgs e)
        {
            Grid1.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void Grid1_RowCommand(object sender, GridCommandEventArgs e)
        {

        }
    }
}