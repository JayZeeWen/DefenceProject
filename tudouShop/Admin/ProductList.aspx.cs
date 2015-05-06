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
            AjaxPro.Utility.RegisterTypeForAjax(typeof(ProductList));
            if (!IsPostBack)
            {
                BindGrid();
                BindDropDownListDataSet();
            }
        }

        private void BindGrid()
        {
            
            
            BLL.T_Products proBLl = new BLL.T_Products();
            string condition = "";
            //获取数据总条数
            Grid1.RecordCount = proBLl.GetRecordCount(condition);
            //获取分页数据
            DataTable dt = proBLl.GetProducts(condition, "ProID",Grid1.PageIndex,Grid1.PageSize).Tables[0];

            Grid1.DataSource = dt;
            Grid1.DataBind();

        }

        protected void Grid1_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            Grid1.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        #region 绑定下拉列表数据源
        public void BindDropDownListDataSet()
        {
            //类型数据源
            BLL.T_Type typebll = new BLL.T_Type ();
            DataTable dt = typebll.GetAllList().Tables[0];
            ddlType.DataSource = dt;
            ddlType.DataTextField = "TName";
            ddlType.DataValueField = "TID";
            ddlType.DataBind();

            //品牌数据源
            BLL.T_Brand brandBll = new BLL.T_Brand();
            DataTable Branddt = brandBll.GetAllList().Tables[0];
            ddlType.DataSource = Branddt;
            ddlType.DataTextField = "BraName";
            ddlType.DataValueField = "BraID";
            ddlType.DataBind();
 
        }
        #endregion

        [AjaxPro.AjaxMethod]
        public string getTypeName(int TID)
        {
            BLL.T_Type typebll = new BLL.T_Type();
            Model.T_Type type = typebll.GetModel(TID);
            return type.TName;
        }

        [AjaxPro.AjaxMethod]
        public string getBrandName(int BID)
        {
            BLL.T_Brand bll = new BLL.T_Brand();
            Model.T_Brand brand = bll.GetModel(BID);
            return brand.BraName;
        }

        
    }
}