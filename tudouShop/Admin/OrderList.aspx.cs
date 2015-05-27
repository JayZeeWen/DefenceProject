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

        protected string GetEditUrl(object id, object name)
        {
            return InfoWindows.GetShowReference("OrderInfo.aspx?id=" + id, "编辑 - " + name);
        }

        private DataRow FindRowByID(int rowID)
        {
            DataTable table = GetSourceTable();
            foreach (DataRow row in table.Rows)
            {
                if (Convert.ToInt32(row["OrderID"]) == rowID)
                {
                    return row;
                }
            }
            return null;
        }

        [AjaxPro.AjaxMethod]
        public void Delive(int id)
        {
            EShop.BLL.T_Orders orderbll = new EShop.BLL.T_Orders ();
            EShop.Model.T_Orders order = orderbll.GetModel(id);
            order.state = "2";
            orderbll.Update(order);
        }

    }
}