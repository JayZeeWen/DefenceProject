using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using FineUI;
using Newtonsoft.Json.Linq;

namespace EShop
{
    public partial class ProductList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        private void BindGrid()
        {
            
            
            BLL.T_Products proBLl = new BLL.T_Products();
            string condition = "";
            //获取数据总条数
            Grid1.RecordCount = proBLl.GetRecordCount(condition);
            //获取分页数据
            DataTable dt = proBLl.GetListByPage(condition, "ProID",Grid1.PageIndex,Grid1.PageSize).Tables[0];

            Grid1.DataSource = dt;
            Grid1.DataBind();

        }

        protected void Grid1_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            Grid1.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        
    }
}